using UnityEngine;
using System.Collections;

public class CameraRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Input.gyro.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        Quaternion gattitude = Input.gyro.attitude;
        gattitude.x *= -1;
        gattitude.y *= -1;
        var rot =
            Quaternion.Euler(90, 0, 0) * gattitude;
        this.transform.Rotate(0, (rot.y * 1), 0);
	}

    void OnDestroy() {
        Input.gyro.enabled = false;
    }
}
