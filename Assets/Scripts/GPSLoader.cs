using UnityEngine;
using System.Collections;

public class GPSLoader : MonoBehaviour {
    IEnumerator Start() {
        if(!Input.location.isEnabledByUser) {
            yield break;
        }
        Input.location.Start();
        int maxWait = 120;
        while(Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        if(maxWait < 1) {
            print("Timed out");
            yield break;
        }
        if(Input.location.status == LocationServiceStatus.Failed) {
            print("Unable to determine device location");
            yield break;
        } else {
            print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
        }
        //止めません
        //Input.location.Stop();
    }

    void Update() {
        //GPS情報
        //print("Location\n緯度:" + Input.location.lastData.latitude + " 経度:" + Input.location.lastData.longitude);
    }
}