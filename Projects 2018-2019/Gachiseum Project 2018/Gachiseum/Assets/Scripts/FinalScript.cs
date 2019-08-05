using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScript : MonoBehaviour {

    public GameObject pistolGun;
    public VoiceController vController;

    public GameObject Key;
    public GameObject keyPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == pistolGun.name)
        {
            pistolGun.transform.position = transform.position;
            pistolGun.GetComponent<ObjectController>().enabled = false;
            pistolGun.GetComponent<DecorationObject>().enabled = false;
            pistolGun.GetComponent<BoxCollider>().enabled = false;

            vController.PlayToilet();
            Key.transform.position = keyPoint.transform.position;
            Key.SetActive(true);
            var nulenie = new Vector3(keyPoint.transform.position.x, 0, keyPoint.transform.position.z);
            Key.transform.position = nulenie;
        }
    }
}
