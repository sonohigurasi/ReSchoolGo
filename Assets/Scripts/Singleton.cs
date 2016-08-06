using UnityEngine;
using System.Collections;

public class Singleton : MonoBehaviour {
    public static Singleton instance;

    void Awake ()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else if(instance == null)
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
