using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour {
    public static Life Instance;
    public int MaxLives;
    int Lives;
    void Awake() {
        Instance = this;
        Lives = MaxLives-5;
        DisplayLives();
    }
    public void DisplayLives() {
        GetComponent<RectTransform>().sizeDelta = new Vector2(144f * (Lives / (float)MaxLives),22);
    }
    public void SubtractLives(int num) {
        Lives -= num;
        if(Lives <= 0) {
            //DIE
            Debug.Log("You Lost!");
            return;
        }
        DisplayLives();
    }
}
