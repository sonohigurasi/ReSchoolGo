using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameStartUIMgr : MonoBehaviour
{
    public Text SubjectUI;
    public Text timeUI;
    public Text descriptionUI;

    public void SetSubject(string subject_name)
    {
        SubjectUI.text = "科目名　　　" + subject_name;
    }
    public void SetTimeUI(float time)
    {
         timeUI.text = "クエスト開始期限残り   " + ((int)time / 60).ToString("D2") + ":" + (time % 60).ToString("00.00");
        //timeUI.text = "fdsafdasfdsafdsafdas";

    }
    public void SetDescription(string description)
    {
        descriptionUI.text = description;

    }
}
