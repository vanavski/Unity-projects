using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationObject : MonoBehaviour {

    public GameObject player;
    private Vector3 look;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(player == null)
        {
            var _player = GameObject.FindGameObjectWithTag("Player");
            look = new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z);
        } else
            look = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(look);
    }
}
