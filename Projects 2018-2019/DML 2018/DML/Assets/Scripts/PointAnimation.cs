using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAnimation : MonoBehaviour 
{
	public float a;
	public float b;
	public float speed;
	float startX;
	float startZ;
	
	float t;

	void Start () {
		a = Random.Range(0.5f, 1f);
		b = Random.Range(1f, 2f);
		speed = Random.Range(-2f, 2f);
		t = Random.Range(-3f, 3f);

		startX = transform.position.x;
		startZ = transform.position.z;
	}
	
	void Update () 
	{
		t += 0.1f;
		transform.position = new Vector3(
			startX + a * Mathf.Cos(t * speed),
			transform.position.y,
			startZ + b * Mathf.Sin(t * speed));// * Time.deltaTime;	
	}
}
