using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuildingButton : MonoBehaviour {
    public Button button;
    public GameObject Panel;
	public void OnClick()
    {
        switch (button.GetComponentInChildren<Text>().text)
        {
            case "Gold Mine":
                Debug.Log("Gold Mine");
                
                break;
            default:
                Debug.Log("WTF??");
                break;
        }

    }
}
