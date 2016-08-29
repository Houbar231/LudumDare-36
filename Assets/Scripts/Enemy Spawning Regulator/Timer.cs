using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour
{
    float timer = 0f;
    public Text timerText;
    private bool Run = false;
    public static Timer Instance;
    // Use this for initialization
    void Awake()
    {
        Instance = this;
    }
    public void StartTimer()
    {
        Run = true;
        StartCoroutine(Ienum());

    }
    // Update is called once per frame
    /*void FixedUpdate () {
        if (Run)
        {
            timer += Time.deltaTime * 10;
            timerText.text = timer.ToString();
        }

	}*/
    public float StopTimer()
    {
        StopCoroutine(Ienum());
        return timer;
    }
    public IEnumerator Ienum()
    {
            while (Run)
            {
                for (int i = 0; i < Mathf.CeilToInt((timer / 10f) * 0.1f); i++)
                {
                    Enemy.Instance.SpawnEnemyUnit();
                    yield return new WaitForSeconds(1);
                }
                timer += 1;
            timerText.text = timer.ToString();
            }
        
    }
}
