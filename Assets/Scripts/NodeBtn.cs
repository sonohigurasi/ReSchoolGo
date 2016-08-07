using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NodeBtn : MonoBehaviour {
    static public string selectImageName;

    public Text imageNameText;
    public sc_ChangeScene changeScene;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PushNodeBtn()
    {
        Debug.Log("test:" + imageNameText.text);
        NodeBtn.selectImageName = imageNameText.text;
        changeScene.changeScene();
    }
}
