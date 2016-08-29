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

    public IEnumerator Every001Sec() {
        yield return new WaitForSeconds(1);
        while(IsRunning) {
            Bullets.Instance.TryFindTargets();
            yield return new WaitForSeconds(0.01f);
        }
    }
    public IEnumerator Every05Sec() {
        yield return new WaitForSeconds(1);
        while(IsRunning) {
            Enemy.Instance.MoveAll();
            yield return new WaitForSeconds(0.5f);
        }
    }
    public IEnumerator Every1Sec() {
        yield return new WaitForSeconds(1);
        while(IsRunning) {
            Enemy.Instance.SpawnEnemyUnit();
            yield return new WaitForSeconds(1);
        }
    }
    bool IsRunning;
    void OnEnable() {
        IsRunning = true;  
    }
    void Start() {
        StartCoroutine(Every001Sec());
        StartCoroutine(Every05Sec());
        StartCoroutine(Every1Sec());
    }
    void OnDisable() {
        IsRunning = false;
    }
}
