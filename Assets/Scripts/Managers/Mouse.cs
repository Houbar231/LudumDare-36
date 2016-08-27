using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {
    public static Mouse Instance;
    void Awake() {
        Instance = this;
    }
    public MapTile SelectedTile;

    void Update() {
        Vector3 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        int MouseX = Mathf.FloorToInt(MousePosition.x);
        int MouseY = Mathf.FloorToInt(MousePosition.y);

        if(Input.GetMouseButtonDown(0) && MouseX >= 0 && MouseX < GeneralReference.r.Width && MouseY >= 0 && MouseY < GeneralReference.r.Height) {
            SelectedTile = Map.Instance.Tiles[MouseX, MouseY];
            Debug.Log(SelectedTile.TileGO.name);
        }
    }
}
