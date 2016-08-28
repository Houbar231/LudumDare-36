﻿using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class BuildingButton : MonoBehaviour {
    public Button button;
    public Sprite sprite;
    public string bmode_Text;
    public bool buildingMode = false;
    public static BuildingButton Instance;
    public Text Bmode_text;
    public Button Bmode;
    public string BuildingName;
    public GameObject BuildingMenuHider;
    public bool TileBlocker;
    public bool BulletShooter360Dgr;

    public void Awake() {
        Instance = this;
    }

    public void Bmode_Click() {
        Debug.Log("Button Pressed");
        HideOnStart.Instance.BHider.SetActive(false);
        buildingMode = false;
        BuildingMenuHider.SetActive(true);
    }

    public void OnClick() {
        BuildingShop.Instance.CloseShop();
        buildingMode = true;

        //HideOnStart.Instance.BHider.SetActive(false);
        Bmode_text.text = bmode_Text;
        HideOnStart.Instance.BHider.SetActive(true);
        BuildingMenuHider.SetActive(false);
    }

    void FixedUpdate() {
        if(Input.GetMouseButton(1) && buildingMode == true) {
            Vector3 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int MouseX = Mathf.FloorToInt(MousePosition.x);
            int MouseY = Mathf.FloorToInt(MousePosition.y);
            if((MouseX >= 0 && MouseX < GeneralReference.r.Width && MouseY >= 0 && MouseY < GeneralReference.r.Height) && !Building.Instance.IsBuildingOnTile(MouseX, MouseY) && ! Enemy.Instance.IsOccupiedByEnemy(MouseX, MouseY)) {
                Debug.Log("A");
                MapTile SelectedTile = Map.Instance.Tiles[MouseX, MouseY];
                GameObject GO = new GameObject(BuildingName);
                GO.AddComponent<SpriteRenderer>().sprite = sprite;
                GO.transform.position = new Vector3(SelectedTile.Data.x, SelectedTile.Data.y, 0);
                Building.Instance.Buildings.Add(new Vector2(MouseX, MouseY));
                if(TileBlocker) {
                    BuildingScripts.TileBlocker(MouseX, MouseY);
                }
                if(BulletShooter360Dgr) {
                    BuildingScripts.BShooter360Dgr(MouseX, MouseY);
                }
            }
        }

    }
}

public static class BuildingScripts {
    public static void TileBlocker(int x, int y) {
        Map.Instance.Tiles[x, y].Data.IsWalkable = false;
        Map.Instance.SetUpPathfinding();
    }
    public static void BShooter360Dgr(int x, int y) {
        new BulletShooter360Dgr(x, y);
    }
}