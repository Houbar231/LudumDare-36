using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {
    public GameObject BuildMenu;
    public GameObject PlayMenu;

    public void StartMenu() {
        BuildMenu.SetActive(false);
        PlayMenu.SetActive(true);
        OneManagerToRuleThemAll.Instance.StartEnemySpawn();
    }
}
