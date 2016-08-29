using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Money : MonoBehaviour {
    public static Money Instance;
    void Awake() {
        Instance = this;
        MoneyStatus.text = MoneyCount.ToString();
    }

    public int MoneyCount;
    public Text MoneyStatus;

    public void AddMoney(int sum) {
        MoneyCount += sum;
        MoneyStatus.text = MoneyCount.ToString();
    }
    public void SubtractMoney(int sum) {
        MoneyCount -= sum;
        MoneyStatus.text = MoneyCount.ToString();
    }
    public bool IsEnough(int sum) {
        return MoneyCount >= sum;
    }
}
