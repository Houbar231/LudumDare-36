using UnityEngine;
using System.Collections;

public class BuildingUI : MonoBehaviour {
    public static BuildingUI Instance;
    void Awake() {
        Instance = this;
    }

    public void ConstructBuilding(string name) {
        BuildType Type = null;
        MapTile Tile = Mouse.Instance.SelectedTile;
        foreach(BuildType bt in Building.Instance.BuildingTypes) {
            if(bt.Name == name) {
                Type  = bt;
            }
        }
        if(Type == null) {
            Debug.LogError("UI requested the building of an unknown building type - " + name);
            return;
        }
        if(Tile == null) {
            Debug.LogError("UI requested the building without a selected tile");
            return;
        }

        if(! Building.Instance.IsBuildingOnTile(Tile.Data.x, Tile.Data.y)) {
            new Build(Tile.Data.x, Tile.Data.y, Type);
        }
    }
    public void DemolishBuilding() {
        MapTile Tile = Mouse.Instance.SelectedTile;
        if(Tile != null) {
            Build ToDemolish = null;
            foreach(Build b in Building.Instance.Builds) {
                if(b.Data.x == Tile.Data.x && b.Data.y == Tile.Data.y)
                    ToDemolish = b;
            }
            if(ToDemolish != null) {
                if(ToDemolish.Data.Type.TileBlocker) {
                    Map.Instance.Tiles[ToDemolish.Data.x, ToDemolish.Data.y].Data.IsWalkable = true;
                    Map.Instance.SetUpPathfinding();
                }
                if(ToDemolish.Data.Type.BulletShooter360Dgr) {
                    foreach(BulletShooter360Dgr s in Bullets.Instance.ActiveBulletShooters) {
                        if(s.x == Tile.Data.x && s.y == Tile.Data.y)
                            Bullets.Instance.ActiveBulletShooters.Remove(s);
                    }
                }
                Destroy(ToDemolish.GO);
                Building.Instance.Builds.Remove(ToDemolish);
            }
        }
    }
}
