using UnityEngine;
using System.Collections;

public class GeneralReference : MonoBehaviour {
    public static GeneralReference r;
    void Awake() {
        r = this;
    }
    public int Width, Height;
}
