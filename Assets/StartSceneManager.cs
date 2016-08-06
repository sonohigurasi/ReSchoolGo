using UnityEngine;
using System.Collections;

public class StartSceneManager : MonoBehaviour {

   GameStartUIMgr uimanager;
    public float start_time  = 82800;
    public float span;

    float time;
	// Use this for initialization
	void Start () {
        span = start_time -(System.DateTime.Now.Hour * 60 * 60 + System.DateTime.Now.Minute * 60 + System.DateTime.Now.Second);
        uimanager = this.GetComponent<GameStartUIMgr>();
        uimanager.SetSubject("解析学");
        uimanager.SetDescription("ゴミ授業");
        
        
	}
	
	// Update is called once per frame
	void Update () {
        span -= Time.deltaTime;
        uimanager.SetTimeUI(span);
    }
}
