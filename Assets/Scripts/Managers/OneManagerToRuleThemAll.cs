using UnityEngine;
using System.Collections;

public class OneManagerToRuleThemAll : MonoBehaviour {
    public static OneManagerToRuleThemAll Instance;
    public IEnumerator Instantiate() {
        Instances();
        yield return new WaitForEndOfFrame();
        First();
        yield return new WaitForEndOfFrame();
        Second();
        yield return new WaitForEndOfFrame();
        Third();
        yield return new WaitForEndOfFrame();
        Fourth();
        yield return new WaitForEndOfFrame();
        Fifth();
    }
    public void Instances() {

    }
    public void First() {

    }
    public void Second() {

    }
    public void Third() {

    }
    public void Fourth() {

    }
    public void Fifth() {

    }

    public IEnumerator Every04Sec() {
        yield return new WaitForSeconds(0.4f);
        while(IsRunning) {
            Bullets.Instance.AllShoot();
            Bullets.Instance.TryFindTargets();
            yield return new WaitForSeconds(0.4f);
        }
    }
    public IEnumerator Every05Sec() {
        yield return new WaitForSeconds(1);
        while(IsRunning) {
            Enemy.Instance.MoveAll();
            yield return new WaitForSeconds(0.5f);
        }
    }
    public IEnumerator EnemySpawn() {
        yield return new WaitForSeconds(1);
        while(IsRunning) {
            Enemy.Instance.SpawnEnemyUnit();
            yield return new WaitForSeconds(1);
        }
    }
    bool IsRunning;
    void Awake() {
        Instance = this;
    }
    void OnEnable() {
        IsRunning = true;  
    }
    void Start() {
        StartCoroutine(Every04Sec());
        StartCoroutine(Every05Sec());
    }
    public void StartEnemySpawn() {
        StartCoroutine(EnemySpawn());
    }
    void OnDisable() {
        IsRunning = false;
    }
}
