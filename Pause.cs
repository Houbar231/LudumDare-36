using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
    public bool paused = false;
    public GameObject PauseHider;
	// Use this for initialization
	void Start () {
        PauseHider.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                Time.timeScale = 0;
                paused = true;
                PauseHider.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                paused = false;
                PauseHider.SetActive(false);
            }

        }
    }
}
