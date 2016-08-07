using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class sc_ChangeScene : MonoBehaviour {
    public string sceneName;

    public void changeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
