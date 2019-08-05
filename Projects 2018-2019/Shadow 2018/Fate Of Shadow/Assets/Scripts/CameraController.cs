using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{
	//constaints of camera on coordinates
	[SerializeField]
	private float xMax;
	[SerializeField]
	private float xMin;

	public Transform target;
	public Vector3 offset;
	public float smoothSpeed;
	private float currentDifference;
	public float difference;

	public void CheckArea()
	{
		currentDifference = Mathf.Abs(transform.position.y - target.transform.position.y);
		var desiredPosition = target.position + offset;
		if (currentDifference > difference)
			transform.position = Vector3.Lerp(
				transform.position,
				desiredPosition,
				smoothSpeed * Time.deltaTime);
		else
		{
			transform.position = new Vector3(
				Mathf.Clamp(target.position.x,xMin,xMax), 
				transform.position.y,
				transform.position.z
				);
		}
	}

	void Start()
	{
		target = GameObject.Find("Player").transform;
	}

	void FixedUpdate()
	{
		CheckArea();
	}
}
