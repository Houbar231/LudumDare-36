using UnityEngine;
using System.Collections;

public class SpriteReference : MonoBehaviour {
    public static SpriteReference r;

    public Sprite DefaultTileSprite;
    public Sprite Enemysprite;

    void Awake() {
        r = this;
    }
}
