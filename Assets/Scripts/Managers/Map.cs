using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {
    public static Map Instance;
    public MapTile[,] Tiles;
    void Awake() {
        Instance = this;
    }
    void OnEnable() {
        Tiles = new MapTile[GeneralReference.r.Width, GeneralReference.r.Height];
        for(int i = 0; i < GeneralReference.r.Width; i++) {
            for(int j = 0; j < GeneralReference.r.Height; j++) {
                Tiles[i, j] = new MapTile(i, j);
            }
        }
    }
    void Start() {
        Pathfinding.Instance.DoPathfinding();
        foreach(MapTile mt in Pathfinding.Instance.NextTileToDest.Keys) {
            Debug.Log("From tile " + mt.Data.x + ", " + mt.Data.y + " To tile " + Pathfinding.Instance.NextTileToDest[mt].Data.x + ", " + Pathfinding.Instance.NextTileToDest[mt].Data.y);
        }
    }
}
