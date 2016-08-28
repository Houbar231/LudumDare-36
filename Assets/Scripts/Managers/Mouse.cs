using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Mouse : MonoBehaviour {
    public static Mouse Instance;
    void Awake() {
        Instance = this;
    }
    public MapTile SelectedTile;

    void Update() {
        if(! EventSystem.current.IsPointerOverGameObject()) {
            Vector3 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int MouseX = Mathf.FloorToInt(MousePosition.x);
            int MouseY = Mathf.FloorToInt(MousePosition.y);

            if(Input.GetMouseButtonDown(0) && MouseX >= 0 && MouseX < GeneralReference.r.Width && MouseY >= 0 && MouseY < GeneralReference.r.Height) {
                SelectedTile = Map.Instance.Tiles[MouseX, MouseY];
            }
        }
        if(gameObject.transform.Find("Selector") != null) {
            Destroy(gameObject.transform.Find("Selector").gameObject);
        }
        if(SelectedTile != null) {
            GameObject Sel = new GameObject("Selector");
            Debug.Log(SelectedTile.TileGO.name);
            Sel.transform.position = SelectedTile.TileGO.transform.position + new Vector3(0, 0, -0.1f);
            Sel.AddComponent<SpriteRenderer>().sprite = SpriteReference.r.SelSprite;
            Sel.transform.SetParent(gameObject.transform); 
        }
    }
}
