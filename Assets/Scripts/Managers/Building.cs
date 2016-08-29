using UnityEngine;
using System.Collections.Generic;

public class Building : MonoBehaviour {
    public static Building Instance;
    void Awake() {
        Instance = this;
    }
    [System.NonSerialized]
    public List<Build> Builds;
    public BuildType[] BuildingTypes;

    void Start() {
        Builds = new List<Build>();
    }
    public bool IsBuildingOnTile(int x, int y) {
        foreach(Build b in Builds) {
            if(b.Data.x == x && b.Data.y == y)
                return true;
        }
        return false;
    }

}

public class Build {
    public GameObject GO;
    public BuildData Data;

    public Build(int x, int y, BuildType type) {
        Data = new BuildData(x, y, type);
        GO = new GameObject(type.Name);
        GO.transform.position = new Vector3(x, y);
        GO.AddComponent<SpriteRenderer>().sprite = type.Sprite;

        if(type.TileBlocker)
            BuildingScripts.TileBlocker(x, y);
        if(type.BulletShooter360Dgr)
            BuildingScripts.BShooter360Dgr(x, y);

        Building.Instance.Builds.Add(this);
    }
}
public class BuildData {
    public BuildType Type;
    public int x, y;

    public BuildData(int x, int y, BuildType Type) {
        this.x = x;
        this.y = y;
        this.Type = Type;
    }
}

[System.Serializable]
public class BuildType {
    public string Name;
    public Sprite Sprite;
    public int Price;

    public bool TileBlocker;
    public bool BulletShooter360Dgr;
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