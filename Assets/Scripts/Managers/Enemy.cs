using UnityEngine;
using System.Collections.Generic;
using System;

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
        MapTile SpawnTile = ValidSpawnTiles[UnityEngine.Random.Range(0, ValidSpawnTiles.Count)];
        EnemiesOnMap.Add(new EnemyUnit(SpawnTile.Data.x, SpawnTile.Data.y));
    }

    public void MoveAll() {
        foreach(EnemyUnit eu in EnemiesOnMap) {
            eu.MoveToDest();
        }
    }
    public bool IsOccupiedByEnemy(int x, int y) {
        foreach(EnemyUnit e in EnemiesOnMap) {
            if(e.Data.x == x && e.Data.y == y) {
                return true;
            }
        }
        return false;
    }
    public EnemyUnit GetClosestUnit(int x, int y, float range) {
        EnemyUnit ret = null;
        float MinDistance = 1000000000;
        foreach(EnemyUnit eu in EnemiesOnMap) {
            if(Vector2.Distance(new Vector2(x, y), new Vector2(eu.Data.x, eu.Data.y)) <= range) {
                MinDistance = Vector2.Distance(new Vector2(x, y), new Vector2(eu.Data.x, eu.Data.y));
                ret = eu;
            }
        }
        return ret;
    }
}
public class EnemyUnit {
    public event Action<EnemyUnit> OnEnemyDie;

    public GameObject GO;
    public EnemyData Data;

    public EnemyUnit(int x, int y) {
        GO = new GameObject("Enemy");
        GO.transform.position = new Vector3(x, y);
        GO.AddComponent<SpriteRenderer>().sprite = SpriteReference.r.Enemysprite;
        Data = new EnemyData(x, y);
    }
    public void MoveToDest() {
        if(Map.Instance == null)
            Debug.Log("A");
        if(Data.x != Map.Instance.DestTile.Data.x || Data.y != Map.Instance.DestTile.Data.y) {
            GO.transform.position = new Vector3(Map.Instance.NextToDestTile[Map.Instance.Tiles[Data.x, Data.y]].Data.x, Map.Instance.NextToDestTile[Map.Instance.Tiles[Data.x, Data.y]].Data.y, -0.001f);
            Data.x = Map.Instance.NextToDestTile[Map.Instance.Tiles[Data.x, Data.y]].Data.x;
            Data.y = Map.Instance.NextToDestTile[Map.Instance.Tiles[Data.x, Data.y]].Data.y;
        }
    }
    public void TakeDamage(float Damage) {
        Data.Hitpoints -= Damage;
        if(Data.Hitpoints <= 0) {
            OnEnemyDie(this);
            GameObject.Destroy(GO);
            Enemy.Instance.EnemiesOnMap.Remove(this);
        }
    }
}
public class EnemyData {
    public int x, y;
    public float Hitpoints = 100;
    public EnemyData(int x, int y) {
        this.x = x;
        this.y = y;
    }
}
