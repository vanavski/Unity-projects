using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject center; 
	public GameObject sphere;
	
	[SerializeField]
	private float speed = 5f;

	[SerializeField]
	private float turningSpeed = 5f;
	void Update () 
	{
		center.transform.rotation *= Quaternion.Euler(0f, turningSpeed * Time.deltaTime, 0f);

		if (Input.GetKey(KeyCode.W))
		{
			sphere.transform.rotation = center.transform.rotation;
			sphere.transform.position += sphere.transform.rotation * new Vector3(
            0f,
            0f,
			speed * Time.deltaTime
        );
		}

		if (Input.GetKey(KeyCode.S))
		{
			sphere.transform.rotation = center.transform.rotation;
			sphere.transform.position -= sphere.transform.rotation * new Vector3(
            0f,
            0f,
			speed * Time.deltaTime
        );
		}

		if (Input.GetKey(KeyCode.D))
		{
			sphere.transform.rotation = Quaternion.Euler(center.transform.rotation.x, center.transform.rotation.y - 90, center.transform.rotation.z);
			sphere.transform.position +=  new Vector3(
            0f,
            0f,
			speed * Time.deltaTime
        );
		}

		if (Input.GetKey(KeyCode.A))
		{
			
			sphere.transform.position -=  new Vector3(
            0f,
            0f,
			speed * Time.deltaTime
        );
		sphere.transform.rotation = Quaternion.Euler(center.transform.rotation.x, center.transform.rotation.y + 90, center.transform.rotation.z);
		}
	}
}
