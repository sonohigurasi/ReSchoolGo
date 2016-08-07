using UnityEngine;
using System.Collections;

public class UserManager : Singleton {
    const string kIsQuestOrder = "OrderKey";
    const string kSelectQuestNumber = "SelectNumberKey";
    const string kClearCount = "ClearKey";

    public bool isQuestOrder;
    public int selectQuestNumber;
    public int clearCount;

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
