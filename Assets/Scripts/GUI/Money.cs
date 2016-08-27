using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Money : MonoBehaviour {
    private int ActualMoney = 50;
    public Text MoneyCounter;
    public static Money Instance;

    void Awake()
    {
        Instance = this;
    }

    public void AddMoney(int Count)
    {
        ActualMoney += Count;
    }

    public void LessMoney(int Count)
    {
        ActualMoney -= Count;
    }

	void Update () {
        MoneyCounter.text = ActualMoney.ToString();
	}
}
