using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour {
    
    [SerializeField]
    RectTransform prefab = null;

    void Start()
    {
        PastQuestionRecord[] test = Database.getAllRecordFromQuestionTable();

        for (int i = 0; i < test.Length; i++)
        {
            var item = GameObject.Instantiate(prefab) as RectTransform;
            item.SetParent(transform, false);

            var text = item.GetComponentInChildren<Text>();
            text.text = test[i].imageName;
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
