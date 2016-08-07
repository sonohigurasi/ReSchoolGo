using UnityEngine;
using System.Collections;

public class FaceStateMgr : MonoBehaviour {

    public UnityChan.FaceUpdate update;
    Animator anim;
    public int start_num;
    public bool start_animation;
	// Use this for initialization
	void Start () {
        // update.ChangeFace("smile@sd_generic");
        anim = this.GetComponent<Animator>();
        if(start_animation)UpdateState(start_num);

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
