using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BTN_build : MonoBehaviour {
    public void OnClickFunction()
    {
        Debug.Log("Building Menu");
        BuildingShop.Instance.OpenShop();
        //canvasObject.SetActive(false);

    }
}
