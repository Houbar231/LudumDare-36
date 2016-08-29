using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Sound : MonoBehaviour {
    public static Sound Instance;
    void Awake() {
        Instance = this;
        audios = GetComponentsInChildren<AudioSource>();
    }

    public AudioSource[] audios;
    public Slider SoundLevel;

    public void SetSoundLevel() {
        foreach(AudioSource a in audios) {
            a.volume = SoundLevel.value;
        }
    }
}
