using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sc_image : MonoBehaviour {
    Image img;
    public Sprite[] image;
    int id = 1;

    void Awake()
    {
        Debug.Log(image.Length);
        
        // IDを取得する
        //id = TestSingleton.test.id;
        Texture2D texture = Resources.Load("question" + id) as Texture2D;
        img = GameObject.Find("Canvas/Panel/image").GetComponent<Image>();
        Debug.Log(id);
        img.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);

    }
}
