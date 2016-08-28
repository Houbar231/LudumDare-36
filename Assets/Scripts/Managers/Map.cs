using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Map : MonoBehaviour {
    public static Map Instance;
    public MapTile[,] Tiles;
    public MapTile DestTile;
    [System.NonSerialized]
    public bool IsPathfindingComplete = false;
    public Dictionary<MapTile, MapTile> NextToDestTile;
    void Awake() {
        Instance = this;
    }
    void Start() {
        NextToDestTile = new Dictionary<MapTile, MapTile>();
        Tiles = new MapTile[GeneralReference.r.Width, GeneralReference.r.Height];
        for(int i = 0; i < GeneralReference.r.Width; i++) {
            for(int j = 0; j < GeneralReference.r.Height; j++) {
                Tiles[i, j] = new MapTile(i, j);
            }
        }
        DestTile = Tiles[GeneralReference.r.Width / 2, GeneralReference.r.Height/2];
        SetUpPathfinding();
        Enemy.Instance.ValidSpawnTiles = GetEdgeTiles();
        for(int i = 0; i < 4; i++) {
            Enemy.Instance.SpawnEnemyUnit();
        }
        new BulletShooter360Dgr(4, 4);
        Bullets.Instance.AllShoot();
    }
    public List<MapTile> GetEdgeTiles() {
        List<MapTile> ret = new List<MapTile>();
        for(int i = 0; i < GeneralReference.r.Width; i++) {
            for(int j = 0; j < GeneralReference.r.Height; j++) {
                if(i == 0 || i == GeneralReference.r.Width - 1 || j == 0 || j == GeneralReference.r.Height-1) {
                    ret.Add(Tiles[i, j]);
                }
            }
        }
        return ret;
    }
    public void SetUpPathfinding() {
        IsPathfindingComplete = false;
        NextToDestTile.Clear();
        Queue<MapTile> ToBeSearched = new Queue<MapTile>();

        ToBeSearched.Enqueue(DestTile);
        while(ToBeSearched.Count > 0 ) {
            MapTile ToBeSearchedNext = ToBeSearched.Dequeue();

            for(int i = Mathf.Max(ToBeSearchedNext.Data.x-1,0); i <= Mathf.Min(ToBeSearchedNext.Data.x+1, GeneralReference.r.Width-1); i++) {
                for(int j = Mathf.Max(ToBeSearchedNext.Data.y - 1, 0); j <= Mathf.Min(ToBeSearchedNext.Data.y + 1, GeneralReference.r.Height-1); j++) {
                    if(! NextToDestTile.ContainsKey(Tiles[i,j])) {
                        if(ToBeSearchedNext.Data.IsWalkable) {
                            NextToDestTile.Add(Tiles[i, j], ToBeSearchedNext);
                            ToBeSearched.Enqueue(Tiles[i, j]);
                            Debug.Log("Dneuifsuyjcisthárdbgdrbhoedssvadbhorgiefgzioioqdfbuzio");
                        }
                    }
                }
            }
        }
        IsPathfindingComplete = true;
    }
}