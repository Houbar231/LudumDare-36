using UnityEngine;
using System.Collections.Generic;

public class Building : MonoBehaviour {
    public static Building Instance;
    void Awake() {
        Instance = this;
    }

    public List<Vector2> Buildings;
    void Start() {
        Buildings = new List<Vector2>();
    }
    public bool IsBuildingOnTile(int x, int y) {
        foreach(Vector2 v2 in Buildings) {
            if(new Vector2(x, y) == v2)
                return true;
        }
        return false;
    }
}
