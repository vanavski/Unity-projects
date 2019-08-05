using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ak47 : MonoBehaviour {

    public VoiceController vController;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Object"))
        {

            vController.PlayF2();
            Destroy(this.gameObject);
        }
    }
}
