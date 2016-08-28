using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour {
    public void OnClick()
    {
        SceneManager.LoadScene(1);
    }
}
