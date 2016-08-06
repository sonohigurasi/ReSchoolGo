using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour {
    
    [SerializeField]
    RectTransform prefab = null;

    void Start()
    {
        SubjectDataRecord[] test = Database.getAllRecordFromSubjectTable();

        for (int i = 0; i < test.Length; i++)
        {
            var item = GameObject.Instantiate(prefab) as RectTransform;
            item.SetParent(transform, false);

            var text = item.GetComponentInChildren<Text>();
            text.text = "date:" + test[i].date;
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
