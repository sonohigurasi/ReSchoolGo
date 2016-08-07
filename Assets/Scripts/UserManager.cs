using UnityEngine;
using System.Collections;

public class UserManager : MonoBehaviour {
    const string kIsQuestOrder = "OrderKey";
    const string kSelectQuestNumber = "SelectNumberKey";
    const string kClearCount = "ClearKey";

    public static UserManager instance;

    private bool _isQuestOrder;
    public bool isQuestOrder {
        get { return _isQuestOrder; }
        set {
            _isQuestOrder = value;
            PlayerPrefs.SetString(kIsQuestOrder, _isQuestOrder ? "true" : "false");
        }
    }

    private bool _isWin;
    public bool isWin
    {
        get { return _isWin; }
        set
        {
            if(value)clearCount = clearCount + 1;
            _isWin = value;
        }
    }

    private int _selectQuestNumber;
    public int selectQuestNumber {
        get { return _selectQuestNumber; }
        set {
            _selectQuestNumber = value;
            PlayerPrefs.SetInt(kSelectQuestNumber, _selectQuestNumber);
        }
    }

    private float _remmaingTime;
    public float remmaingTime
    {
        get { return _remmaingTime; }
        set { _remmaingTime = value; }
    }

    private int _clearCount;
    public int clearCount {
        get { return _clearCount; }
        set {
            _clearCount = value;
            PlayerPrefs.SetInt(kClearCount, _clearCount);
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
