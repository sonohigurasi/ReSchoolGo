using UnityEngine;
using System.Collections;

public class CameraRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Input.gyro.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        var tmpAngle = Input.gyro.attitude.eulerAngles;
        this.transform.LookAt(new Vector3(0, tmpAngle.y, 0)); 
	}

    void OnDestroy() {
        Input.gyro.enabled = false;
    }
}
