using UnityEngine;
using System.Collections;

public class StartSceneManager : MonoBehaviour
{

    GameStartUIMgr uimanager;
    public float start_time = 82800;
    public int play_time = 5400;
    public float span;

    float time;
    public SubjectDataRecord subject;
    bool playnow;
    // Use this for initialization
    void Start()
    {

        // データベースからデータを取得
        span = start_time - (System.DateTime.Now.Hour * 60 * 60 + System.DateTime.Now.Minute * 60 + System.DateTime.Now.Second);
        uimanager = this.GetComponent<GameStartUIMgr>();
        uimanager.SetSubject(subject.name);
        uimanager.SetDescription(subject.detail);
        start_time = subject.date;
        playnow = false;
        subject = Database.getRecordFromSubjectTableBySubjectNumber(UserManager.instance.selectQuestNumber)[0];


    }

    // Update is called once per frame
    void Update()
    {
        span -= Time.deltaTime;
        uimanager.SetTimeUI(span);
        // 授業開始から５秒後なのにプレイ中でないなら、クエスト受注失敗
        if(span < -5 && !playnow)
        {

        }
    }

    void OnApplicationPause(bool pauseStatus)
    {
        // ポーズになったときかつ、プレイ中ではないのとき
        if (pauseStatus && !playnow)
        {
            playnow = true;
        }
        // ポーズ復帰かつ、プレイ中のとき
        if( !pauseStatus && playnow)
        {
            // そして授業時間後だった場合、ゲームクリア　それ以外は失敗
            if(span <= -1* play_time)
            {
                // 成功
                UserManager.instance.isWin = true;
            }
            else
            {
                //失敗
                UserManager.instance.isWin = false;
            }
            UserManager.instance.remmaingTime = play_time - span;
            this.GetComponent<sc_ChangeScene>().changeScene();
        }
    }
}
