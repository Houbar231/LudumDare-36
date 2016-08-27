using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuildingShop : MonoBehaviour {
    public GameObject shop;
    public GameObject HUD;
    public GameObject[] InActivePlanes;
    public GameObject[] InActiveScrools;
    public static BuildingShop Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        shop.SetActive(false);
        
    }

    public void OpenShop()
    {
        shop.SetActive(true);
        HUD.SetActive(false);
        foreach (var item in InActiveScrools)
        {
            item.SetActive(false);
        }
        foreach (var item in InActivePlanes)
        {
            item.SetActive(false);
        }
    }

    public void CloseShop()
    {
        shop.SetActive(false);
        HUD.SetActive(true);
    }
}
