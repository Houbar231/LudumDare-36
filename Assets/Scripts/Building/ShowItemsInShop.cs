using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowItemsInShop : MonoBehaviour {
    public GameObject Panel;
    public GameObject Scrool;
    public GameObject[] OtherScrools;
    public GameObject[] OtherPanels;
     public void OnClick()
    {
        Panel.SetActive(true);
        Scrool.SetActive(true);
        foreach (var item in OtherScrools)
        {
            item.SetActive(false);
        }
        foreach (var item in OtherPanels)
        {
            item.SetActive(false);
        }
        Debug.Log(Panel.name + " has been Activated");
    }
}
