using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NodeBtn : MonoBehaviour {
    public Text imageNameText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PushNodeBtn()
    {
        Debug.Log("test:" + imageNameText.text);
    }
}
