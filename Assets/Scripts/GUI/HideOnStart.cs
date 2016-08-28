using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HideOnStart : MonoBehaviour
{
    public GameObject BHider;
    public static HideOnStart Instance;
    public Button Bmode;
    public bool Visible;
    void Awake()
    {
        Instance = this;
        BHider.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

    }
}