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
    public void EnemyReachedDest() {
        Life.Instance.SubtractLives(1);
    }
    public void SpawnEnemyUnit() {
        MapTile SpawnTile = ValidSpawnTiles[UnityEngine.Random.Range(0, ValidSpawnTiles.Count)];
        EnemiesOnMap.Add(new EnemyUnit(SpawnTile.Data.x, SpawnTile.Data.y));
    }

    public void MoveAll() {
        for(int i = 0; i < EnemiesOnMap.Count; i++) {
            EnemyUnit eu = EnemiesOnMap[i];
            eu.MoveToDest();
        }
    }
    public bool IsOccupiedByEnemy(int x, int y) {
        for(int i = 0; i < EnemiesOnMap.Count; i++) {
            EnemyUnit e = EnemiesOnMap[i];
            if(e.Data.x == x && e.Data.y == y) {
                return true;
            }
        }
        return false;
    }
    public EnemyUnit GetClosestUnit(int x, int y, float range) {
        EnemyUnit ret = null;
        float MinDistance = 1000000000;
        for(int i = 0; i < EnemiesOnMap.Count; i++) {
            EnemyUnit eu = EnemiesOnMap[i];
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

    public bool IsDead = false;

    public GameObject GO;
    public EnemyData Data;

    public EnemyUnit(int x, int y) {
        GO = new GameObject("Enemy");
        GO.transform.position = new Vector3(x, y);
        GO.AddComponent<SpriteRenderer>().sprite = SpriteReference.r.Enemysprite;
        Data = new EnemyData(x, y);
    }
    public void MoveToDest() {
        if(! IsDead) {
            if(Map.Instance.IsPathfindingComplete) {
                if(Data.x != Map.Instance.DestTile.Data.x || Data.y != Map.Instance.DestTile.Data.y) {
                    if(Map.Instance.NextToDestTile.ContainsKey(Map.Instance.Tiles[Data.x, Data.y])) {
                        GO.transform.position = new Vector3(Map.Instance.NextToDestTile[Map.Instance.Tiles[Data.x, Data.y]].Data.x, Map.Instance.NextToDestTile[Map.Instance.Tiles[Data.x, Data.y]].Data.y, -0.001f);
                        int mx = Map.Instance.NextToDestTile[Map.Instance.Tiles[Data.x, Data.y]].Data.x;
                        int my = Map.Instance.NextToDestTile[Map.Instance.Tiles[Data.x, Data.y]].Data.y;
                        Data.x = mx;
                        Data.y = my;
                    }
                    else {
                        Debug.Log("2ba 2ye2 li3");
                        for(int i = Mathf.Max(Data.x - 1, 0); i <= Mathf.Min(Data.x + 1, GeneralReference.r.Width - 1); i++) {
                            for(int j = Mathf.Max(Data.y - 1, 0); j <= Mathf.Min(Data.y + 1, GeneralReference.r.Height - 1); j++) {
                                BuildingUI.Instance.DemolishBuilding(i, j);
                            }
                        }
                        Map.Instance.SetUpPathfinding();
                    }
                }
                else {
                    if(!IsDead) {
                        Enemy.Instance.EnemyReachedDest();
                        Die();
                    }
                }
            }
        }
    }
    public void TakeDamage(float Damage) {
        Data.Hitpoints -= Damage;
        if(Data.Hitpoints <= 0) {
            Debug.Log("aAAAAAah");
            Die();

        }
    }
    public void Die() {
        if( OnEnemyDie != null ) OnEnemyDie(this);
        GameObject.Destroy(GO);
        Enemy.Instance.EnemiesOnMap.Remove(this);
        IsDead = true;
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
