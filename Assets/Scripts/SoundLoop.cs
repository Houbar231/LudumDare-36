using UnityEngine;
using System.Collections;

public class SoundLoop : MonoBehaviour {
    public AudioSource source;

	// Use this for initialization
	void Start () {
        source.loop = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
