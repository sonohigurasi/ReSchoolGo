using UnityEngine;
using System.Collections;

public class FaceStateMgr : MonoBehaviour {

    public UnityChan.FaceUpdate update;
    Animator anim;
	// Use this for initialization
	void Start () {
        // update.ChangeFace("smile@sd_generic");
        anim = this.GetComponent<Animator>();
	}
    void Awake()
    {

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UpdateState(int num)
    {
        anim.SetInteger("num", num);
    }

}
