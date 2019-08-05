using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCollision : MonoBehaviour {

    public VoiceController vController;
    public AudioClip clip;
    private bool play;

    private void Start()
    {
        play = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!play)
            {
                vController.PlayWithSpeaker(vController.GetComponent<AudioSource>(), clip);
                play = true;
                Destroy(this.gameObject);
            }
        }
    }

    
}
