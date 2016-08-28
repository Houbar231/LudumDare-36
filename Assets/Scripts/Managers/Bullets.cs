using UnityEngine;
using System.Collections.Generic;

public class Bullets : MonoBehaviour {
    public static Bullets Instance;
    void Awake() {
        Instance = this;
        ActiveBulletShooters = new List<BulletShooter360Dgr>();
    }

    public List<BulletShooter360Dgr> ActiveBulletShooters;
    public void TryFindTargets() {
        foreach(BulletShooter360Dgr bs in ActiveBulletShooters) {
            if(bs.Target == null) {
                bs.FindTarget();
            }
        }
    }
    public void AllShoot() {
        foreach(BulletShooter360Dgr bs in ActiveBulletShooters) {
            bs.Shoot();
        }
    }
}
public interface Shooter { };
public class BulletShooter360Dgr : Shooter{
    public int x, y;
    public Sprite BuildingSprite;
    public float range = 10;
    public float AvgDmg = 50;
    public float DmgSpread = 10;
    public EnemyUnit Target = null;


    public BulletShooter360Dgr(int x, int y) {
        this.x = x;
        this.y = y;
        GameObject GO = new GameObject("Tower");
        GO.AddComponent<SpriteRenderer>().sprite = SpriteReference.r.TowerSprite; //MAKESHIFT
        GO.transform.position = new Vector3(x, y, -0.001f); //MAKESHIFT
        Bullets.Instance.ActiveBulletShooters.Add(this);
    }
    public bool FindTarget() {
        Target = Enemy.Instance.GetClosestUnit(x, y, range);
        if(Target != null) {
            Target.OnEnemyDie += (EnemyUnit) => { FindTarget(); };
            return true;
        }
        return false;
    }
    public void Shoot() {
        if(Target != null && Random.Range(0,100) < 80) {
            Target.TakeDamage(Random.Range(AvgDmg - DmgSpread, AvgDmg + DmgSpread));
        }
    }
}

