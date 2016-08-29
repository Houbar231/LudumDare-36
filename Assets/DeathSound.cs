using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeathSound : MonoBehaviour {
    public static DeathSound Instance;


    void Awake() {
        Instance = this;
    }
    void PlayDeathSound() {
        GetComponent<AudioSource>().Play();
    }
    public void UpdateDeathList() {
        for(int i = 0; i < Enemy.Instance.EnemiesOnMap.Count; i++) {
            EnemyUnit eu = Enemy.Instance.EnemiesOnMap[i];
            eu.OnEnemyDie += (EnemyUnit) => { PlayDeathSound(); };
        }
    }
}
