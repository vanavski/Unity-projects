using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBG : MonoBehaviour 
{
	public float backgroundSize;

	public GameObject Light;

	public bool scroll, par;

	private Transform cameraTransform;
	private Transform[] layers;
	private float viewZone = 5;
	private int leftIndex;
	private int rightIndex;

	public float parallax;
	private float lastCameraX;


	void Start () 
	{
		cameraTransform = Camera.main.transform;

		lastCameraX = cameraTransform.position.x;

		layers = new Transform[transform.childCount];
		for (int i = 0; i < transform.childCount; i++)
		{
			layers[i] = transform.GetChild(i);
		}

		leftIndex = 0;
		rightIndex = layers.Length - 1;
	}

	private void Update()
	{
		// Light.transform.position = new Vector3(Camera.main.transform.position.x,Camera.main.transform.position.y,0);
		
		if (par)
		{
			float deltaX = cameraTransform.position.x - lastCameraX; // -
			transform.position -= Vector3.right * (deltaX * parallax); // +=
		}

		lastCameraX = cameraTransform.position.x;

		if (scroll)
		{
			if (cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone))
			ScrollLeft();
			if (cameraTransform.position.x > (layers[rightIndex].transform.position.x - viewZone))
			ScrollRight();
		}
	}
	
	private void ScrollLeft()
	{
		int LastRight = rightIndex;
		layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - backgroundSize);
		leftIndex = rightIndex;
		rightIndex--;
		if (rightIndex < 0)
			rightIndex = layers.Length - 1;
	}

	private void ScrollRight()
	{
		int LastLeft = leftIndex;
		layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + backgroundSize);
		rightIndex = leftIndex;
		leftIndex++;
		if (leftIndex == layers.Length)
			leftIndex = 0;
	}
}


//CODE GOVNO © CptDrusha
