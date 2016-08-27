using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BTN_CloseClick : MonoBehaviour {
    public void OnClickFunction()
    {
        Debug.Log("Closing Build Menu");
        BuildingShop.Instance.CloseShop();
        //canvasObject.SetActive(false);

    }
}
