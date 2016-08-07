using UnityEngine;
using System.Collections;

public class UserManager : MonoBehaviour {
    const string kIsQuestOrder = "OrderKey";
    const string kSelectQuestNumber = "SelectNumberKey";
    const string kClearCount = "ClearKey";

    public static UserManager instance;

    public bool isQuestOrder {
        get { return isQuestOrder; }
        set {
            isQuestOrder = value;
            PlayerPrefs.SetString(kIsQuestOrder, isQuestOrder ? "true" : "false");
        }
    }
    public bool isWin
    {
        get { return isWin; }
        set
        {
            if(value)clearCount = clearCount + 1;
            isWin = value;
        }
    }
    public int selectQuestNumber {
        get { return selectQuestNumber; }
        set {
            selectQuestNumber = value;
            PlayerPrefs.SetInt(kSelectQuestNumber, selectQuestNumber);
        }
    }
    public float remmaingTime
    {
        get { return remmaingTime; }
        set { remmaingTime = value; }
    }
    public int clearCount {
        get { return clearCount; }
        set {
            clearCount = value;
            PlayerPrefs.SetInt(kClearCount, clearCount);
        }
    }

    void Awake() {
        if(instance != null) {
            Destroy(this.gameObject);
        } else if(instance == null) {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

	// Use this for initialization
	void Start () {
        isQuestOrder = bool.Parse(PlayerPrefs.GetString(kIsQuestOrder, "false"));
        selectQuestNumber = PlayerPrefs.GetInt(kSelectQuestNumber, 0);
        clearCount = PlayerPrefs.GetInt(kClearCount, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
