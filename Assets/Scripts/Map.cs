using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {
    public static Map Instance;

    public MapTi
    void Awake() {
        Instance = this;
    }
}
