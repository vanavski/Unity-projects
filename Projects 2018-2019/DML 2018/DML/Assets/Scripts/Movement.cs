using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour 
{
	[SerializeField]
	private float speed = 10f;
	
	void Update () 
	{
		if (Input.GetKey(KeyCode.D))
		{
		    transform.position += new Vector3(0,0,1) * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.G))
		{
		    transform.position += new Vector3(0,0,-1) * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.R))
    	{
    	    transform.position += new Vector3(1,0,0) * speed * Time.deltaTime;
    	}
    	if (Input.GetKey(KeyCode.F))
    	{
    	    transform.position += new Vector3(-1,0,0) * speed * Time.deltaTime;
    	}
	}	
}
