using UnityEngine;
using System.Collections;

public class SpriteReference : MonoBehaviour {
    public static SpriteReference r;

    public Sprite DefaultTileSprite;
    public Sprite Enemysprite;
    public Sprite TowerSprite;
    public Sprite Mainsprite;

    void Awake() {
        r = this;
    }
}
