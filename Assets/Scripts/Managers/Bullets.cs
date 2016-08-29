using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Bullets : MonoBehaviour {
    public static Bullets Instance;
    void Awake() {
        Instance = this;
        ActiveBulletShooters = new List<BulletShooter360Dgr>();
    }

    public List<BulletShooter360Dgr> ActiveBulletShooters;
    public void TryFindTargets() {
        for(int i = 0; i < ActiveBulletShooters.Count; i++) {
            BulletShooter360Dgr bs = ActiveBulletShooters[i];
            if(bs.Target == null) {
                bs.FindTarget();
            }
        }
    }
    public void AllShoot() {
        for(int i = 0; i < ActiveBulletShooters.Count; i++) {
            BulletShooter360Dgr bs = ActiveBulletShooters[i];
            bs.Shoot();
        }
    }
}
public interface Shooter { };
public class BulletShooter360Dgr : Shooter{
    public int x, y;

    public float range = 5;
    public float AvgDmg = 20;
    public float DmgSpread = 10;
    public float Firerate = 0.4f;
    public EnemyUnit Target = null;
    public bool IsShooting = false;


    public BulletShooter360Dgr(int x, int y) {
        this.x = x;
        this.y = y;
        Bullets.Instance.ActiveBulletShooters.Add(this);
    }
    public bool FindTarget() {
        Target = Enemy.Instance.GetClosestUnit(x, y, range);
        if(Target != null && ! Target.IsDead) {
            Target.OnEnemyDie += (EnemyUnit) => { FindTarget(); };
            return true;
        }
        return false;
    }
    public void Shoot() {
        if(Target != null) {
            if(Random.Range(0, 100) < 80) {
                Debug.Log("Shoot!");
                Target.TakeDamage(Random.Range(AvgDmg - DmgSpread, AvgDmg + DmgSpread));
            }
        }
    }
}

