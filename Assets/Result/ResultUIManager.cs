using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResultUIManager : MonoBehaviour {

    public Text result_message;
    public Text subject_message;
    public Text time_message;
    public Text eval_message;
    public Text item_message;



	// Use this for initialization
	void Start () {
        setUIText(false, "解析学", 5400, "過去問1");
 

    }
	
    //結果をUIテキストにセット
    public void setUIText(bool isClear,string _subject,float _time,string _item_name)
    {
        //リザルト
        result_message.text = isClear ? "クエスト成功！" : "クエスト失敗...";
        //科目名
        subject_message.text = " 科目名: " + _subject;
        //経過時間
        time_message.text = " 時間: " + ((int)_time / 60).ToString("D2") + " : " + ((int)_time % 60).ToString("D2");

        //評価基準
        float minute = (_time / 60);
        if (85 <= minute) eval_message.text = " 評価: S";
        else if (85 > minute && 80 <= minute) eval_message.text = " 評価: A";
        else if (80 > minute && 70 <= minute) eval_message.text = " 評価: B";
        else if (70 > minute && 60 <= minute) eval_message.text = " 評価: C";
        else if (60 > minute) eval_message.text = " 評価: D";

        //入手したアイテム(過去問)
        item_message.text = " 入手過去問:" + _item_name;
    }
}
