using UnityEngine;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {
    public static Enemy Instance;

    public List<MapTile> ValidSpawnTiles;
    public List<EnemyUnit> EnemiesOnMap;

    void Awake() {
        Instance = this;
        //ValidSpawnTiles = new List<MapTile>();
        EnemiesOnMap = new List<EnemyUnit>();
    }
    void Start() {

    }
    public void SpawnEnemyUnit() {
        MapTile SpawnTile = ValidSpawnTiles[Random.Range(0, ValidSpawnTiles.Count)];
        EnemiesOnMap.Add(new EnemyUnit(SpawnTile.Data.x, SpawnTile.Data.y));
    }
}
public class EnemyUnit {
    public GameObject GO;
    public EnemyData Data;

    public EnemyUnit(int x, int y) {
        GO = new GameObject("Enemy");
        GO.transform.position = new Vector3(x, y, -0.001f);
        GO.AddComponent<SpriteRenderer>().sprite = SpriteReference.r.Enemysprite;
        Data = new EnemyData(x, y);
    }
}
public class EnemyData {
    public int x, y;
    public EnemyData(int x, int y) {
        this.x = x;
        this.y = y;
    }
}
