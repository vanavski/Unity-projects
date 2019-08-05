using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {

    public AudioClip sound;
    public AudioSource source;

    [Range(0, 100)]
    public float vol;

    public GameObject point_Light;

    [HideInInspector]
    public bool play;

	// Use this for initialization
	void Start () {
        play = true;
        if(sound != null)
        source.clip = sound;
        if (vol != 0)
        {
            source.volume = vol;
        } else
        {
            vol = 25;
        }
	}

    public void TurnOn()
    {
        if(point_Light != null)
        point_Light.SetActive(true);

        if (source.clip != null)
        {
            source.volume = vol;
            source.Play();
        }
        play = false;
    }
}
