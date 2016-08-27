using UnityEngine;
using System.Collections;

public class SpriteReference : MonoBehaviour {
    public static SpriteReference r;

    public Sprite DefaultTileSprite;

    void Awake() {
        r = this;
    }
}
