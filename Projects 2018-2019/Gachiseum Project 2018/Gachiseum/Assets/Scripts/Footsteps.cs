using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour {


    CharacterController cc;
    AudioSource audio;

	// Use this for initialization
	void Start () {
        cc = GetComponent<CharacterController>();
        audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (cc.isGrounded && cc.velocity.magnitude > 6f && !audio.isPlaying)
        {
            audio.volume = Random.Range(0.6f, 0.8f);
            audio.pitch = Random.Range(0.8f, 1.1f);
            audio.Play();
        }
	}
}
