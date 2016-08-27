using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyStatus : MonoBehaviour
{
    private int ActualMoney = 50;
    public Text MoneyText;
    public void AddMoney(int Count)
    {
        ActualMoney += Count;
    }

    public void LessMoney(int Count)
    {
        ActualMoney -= Count;
    }

    void Update()
    {

    }
}
