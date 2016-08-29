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

        if(!Building.Instance.IsBuildingOnTile(Tile.Data.x, Tile.Data.y) && (Money.Instance.IsEnough(Type.Price))) {
            new Build(Tile.Data.x, Tile.Data.y, Type);
            Money.Instance.SubtractMoney(Type.Price);
        }
        else
            Debug.Log("Not enough money");
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
                Money.Instance.AddMoney(ToDemolish.Data.Type.Price);
                if(ToDemolish.Data.Type.TileBlocker) {
                    Map.Instance.Tiles[ToDemolish.Data.x, ToDemolish.Data.y].Data.IsWalkable = true;
                    Map.Instance.SetUpPathfinding();
                }
                if(ToDemolish.Data.Type.BulletShooter360Dgr) {
                    for(int i = 0; i < Bullets.Instance.ActiveBulletShooters.Count; i++) {
                        BulletShooter360Dgr bs = Bullets.Instance.ActiveBulletShooters[i];
                        if(bs.x == Tile.Data.x && bs.y == Tile.Data.y)
                            Bullets.Instance.ActiveBulletShooters.Remove(bs);
                    }
                }
                Destroy(ToDemolish.GO);
                Building.Instance.Builds.Remove(ToDemolish);
            }
        }
    }
    public void DemolishBuilding(int x, int y) {
        MapTile Tile = Map.Instance.Tiles[x, y];
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
                    for(int i = 0; i < Bullets.Instance.ActiveBulletShooters.Count; i++) {
                        BulletShooter360Dgr bs = Bullets.Instance.ActiveBulletShooters[i];
                        if(bs.x == Tile.Data.x && bs.y == Tile.Data.y)
                            Bullets.Instance.ActiveBulletShooters.Remove(bs);
                    }
                }
                Destroy(ToDemolish.GO);
                Building.Instance.Builds.Remove(ToDemolish);
            }
        }
    }
}
