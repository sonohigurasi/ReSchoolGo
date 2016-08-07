using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class MapSceneController : MonoBehaviour {

    struct QuestBoard {
        QuestPlaceInfo _questPlaceInfo;
        GameObject _questBoard;

        public QuestPlaceInfo questPlaceInfo {
            get { return _questPlaceInfo; }
        }
        public GameObject questBoard {
            get { return _questBoard; }
        }

        public QuestBoard(QuestPlaceInfo placeInfo, GameObject boardObj) {
            this._questPlaceInfo = placeInfo;
            this._questBoard = boardObj;
        }
    }

    float lastTime;
    ArrayList questLocations;
    ArrayList questBoards; //表示中のクエスト掲示板
    public GameObject questBoardPrefab;
    QuestBoard? selectedQuest; //タッチされたクエスト
    LocationCoordinate testLocate;

#region GUIObjects
    public Text titleLabel;
    public Text descriptionLabel;
    public Text questNameLabel;
    public Button closeButton;
    public Button startButton;
#endregion

    // Use this for initialization
	void Start () {
        //Init Variables
        questLocations = new ArrayList();
        questBoards = new ArrayList();

        // TODO: TestData
        /*
        QuestInfo testQuestInfo = new QuestInfo();
        testQuestInfo.questID = 0;
        testQuestInfo.questName = "てすと";
        testQuestInfo.questDescription = "動作確認用のクエスト。";
        testQuestInfo.startTime = new System.DateTime(2000, 1, 1, 9, 0, 0);

        LocationCoordinate testLocation = new LocationCoordinate(123.00f, 123.00f);

        QuestBoard tmpBoard = new QuestBoard(new QuestPlaceInfo(testLocation, testQuestInfo), UnityEngine.Object.Instantiate(questBoardPrefab));
        questBoards.Add(tmpBoard);

        testQuestInfo.questID = 0;
        testQuestInfo.questName = "てすと2";
        testQuestInfo.questDescription = "動作確認用のクエスト2。";
        testQuestInfo.startTime = new System.DateTime(2000, 1, 1, 9, 0, 0);
        testLocation = new LocationCoordinate(122.5f, 122.5f);

        tmpBoard = new QuestBoard(new QuestPlaceInfo(testLocation, testQuestInfo), UnityEngine.Object.Instantiate(questBoardPrefab));
        questBoards.Add(tmpBoard);
        */

        var testGeo = Database.getRecordFromGeoLocationTableByGeoLocationNumber(1);
        testLocate = new LocationCoordinate((float)(testGeo[0].longitude), (float)(testGeo[0].latitude));

        //科目リスト一覧を得る
        var allQuests = Database.getAllRecordFromSubjectTable();
        QuestInfo tmpQuestInfo;
        QuestBoard tmpQuestBoard;
        foreach(SubjectDataRecord item in allQuests) {
            tmpQuestInfo = new QuestInfo();
            tmpQuestInfo.questID = item.number;
            tmpQuestInfo.questName = item.name;
            tmpQuestInfo.questDescription = item.detail;
            tmpQuestInfo.startTime = (int)item.date;
            var boardLocation = Database.getRecordFromGeoLocationTableByGeoLocationNumber(item.geoLocationNumber);
            LocationCoordinate tmpLocate;
            if(boardLocation.Length > 0) {
                tmpLocate = new LocationCoordinate((float)(boardLocation[0].longitude), (float)(boardLocation[0].latitude));
            } else {
                //適当なデータを
                tmpLocate = new LocationCoordinate(0.0f, 0.0f);
            }
            tmpQuestBoard = new QuestBoard(new QuestPlaceInfo(tmpLocate, tmpQuestInfo), UnityEngine.Object.Instantiate(questBoardPrefab));
            questBoards.Add(tmpQuestBoard);
        }

        //Hide GUI
        switchShowGUI(false);

        //save start time
        lastTime = -1.0f;
	}
	
	// Update is called once per frame
	void Update () {
//        Debug.Log("Debugging.");
        //TODO: Debug Cords
        if(Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor) {
            if(Input.GetKey(KeyCode.UpArrow)) {
                testLocate.latitude -= 0.001f;
            }
            if(Input.GetKey(KeyCode.DownArrow)) {
                testLocate.latitude += 0.001f;
            }
            if(Input.GetKey(KeyCode.LeftArrow)) {
                testLocate.longitude += 0.001f;
            }
            if(Input.GetKey(KeyCode.RightArrow)) {
                testLocate.longitude -= 0.001f;
            }
        }

        LocationInfo currentLocationInfo = Input.location.lastData;
        LocationCoordinate currentLocationCoordinate
            = Application.platform != RuntimePlatform.WindowsPlayer && Application.platform != RuntimePlatform.WindowsEditor ?
            new LocationCoordinate(currentLocationInfo.longitude, currentLocationInfo.latitude) :
            testLocate;

        //Hit Ray Check
        if(Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor) {
            if(Input.GetMouseButtonDown(0)) {
                GetTouchQuestBoard(Input.mousePosition);
                if(selectedQuest != null) {
                    //クエスト確認ウインドウを出す
                    questNameLabel.text = selectedQuest.Value.questPlaceInfo.questInfo.questName;
                    descriptionLabel.text = selectedQuest.Value.questPlaceInfo.questInfo.questDescription;
                    switchShowGUI(true);
                    var distance = 1.0 * LocationCoordinate.CalculateDistance(currentLocationCoordinate, selectedQuest.Value.questPlaceInfo.location) / 1000.0;//LocationCoordinate.DistanceLocations(currentLocationCoordinate, item.location);
                    if(distance <= 0.1) {
                        startButton.enabled = true;
                    } else {
                        startButton.enabled = false;
                    }
                }
            }
        } else if(Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer) {
            if(Input.touchCount > 0) {
                GetTouchQuestBoard(Input.touches[0].position);
                if(selectedQuest != null) {
                    //クエスト確認ウインドウを出す
                    questNameLabel.text = selectedQuest.Value.questPlaceInfo.questInfo.questName;
                    descriptionLabel.text = selectedQuest.Value.questPlaceInfo.questInfo.questDescription;
                    switchShowGUI(true);
                    var distance = 1.0 * LocationCoordinate.CalculateDistance(currentLocationCoordinate, selectedQuest.Value.questPlaceInfo.location) / 1000.0;//LocationCoordinate.DistanceLocations(currentLocationCoordinate, item.location);
                    if(distance <= 0.1) {
                        startButton.enabled = true;
                    } else {
                        startButton.enabled = false;
                    }
                }
            }
        }

        if(Time.time - lastTime >= 1.0f) {

            //現在位置を摂る
            var platform = Application.platform;

            //掲示板を一旦消去
            /*
            foreach (GameObject item in GameObject.FindGameObjectsWithTag("QuestBoards")){
                Destroy(item);
            }
            questBoards.Clear();
            */
            //この地点との距離が近いもの(2km以内?)のクエストかつ出現時間帯であればクエスト看板を配置
            foreach(QuestBoard board in questBoards) {
                QuestPlaceInfo item = board.questPlaceInfo;
                var distance = 1.0 * LocationCoordinate.CalculateDistance(currentLocationCoordinate, item.location) / 1000.0;//LocationCoordinate.DistanceLocations(currentLocationCoordinate, item.location);
                GameObject tmpObject = board.questBoard;
                if(distance <= 2.0) { //TODO: Debugging
                    //動的に看板を配置
                    var angle = LocationCoordinate.AngleLocations(currentLocationCoordinate, item.location);
                    Vector3 boardPosition = new Vector3((float)(distance * Math.Cos(angle)), 0.0f, (float)(distance * Math.Sin(angle)));
                    tmpObject.transform.position = boardPosition;
                    tmpObject.SetActive(true);
//                    questBoards.Add(tmpObject);
                } else {
                    tmpObject.SetActive(false);
                }
            }

            lastTime = Time.time;
        }
	}

    private QuestBoard? GetTouchQuestBoard(Vector3 position) {
        Ray ray = Camera.main.ScreenPointToRay(position);
        RaycastHit raycastHit;
        QuestBoard tmpSelectedQuest;
        if(Physics.Raycast(ray, out raycastHit, 1000.0f, (1 << 8))) {
            if(raycastHit.transform.gameObject.tag.Contains("QuestBoard")) {
                GameObject target = raycastHit.transform.gameObject;
                foreach(QuestBoard item in questBoards) {
                    if(item.questBoard == target) {
                        Debug.Log("Find Quest.");
                        Debug.Log("QuestName: " + item.questPlaceInfo.questInfo.questName);
                        selectedQuest = item;
                    }
                }
                Debug.Log("Hit Object.");
            } else {
                Debug.Log("Not Hit Object.");
            }
        } else {
            return null;
        }
        tmpSelectedQuest = (QuestBoard)selectedQuest.Value;
        return tmpSelectedQuest;
    }

    void switchShowGUI(bool isShowGUI) {
        titleLabel.enabled = isShowGUI;
        questNameLabel.enabled = isShowGUI;
        descriptionLabel.enabled = isShowGUI;
        startButton.gameObject.SetActive(isShowGUI);
        closeButton.gameObject.SetActive(isShowGUI);
    }

    //クエストスタートボタンのイベント
    public void OnQuestStartClicked(UnityEngine.Object sender) {
        switchShowGUI(false);
        //ユーザデータ領域にクエスト情報を書き込む
        UserManager.instance.selectQuestNumber = selectedQuest.Value.questPlaceInfo.questInfo.questID;
        //シーン遷移
        GetComponent<sc_ChangeScene>().changeScene();
    }

    //クエスト詳細ウインドウを閉じるボタンのイベント
    public void OnCloseQuestInfoButton(UnityEngine.Object sender) {
        switchShowGUI(false);
        selectedQuest = null;
    }
}
