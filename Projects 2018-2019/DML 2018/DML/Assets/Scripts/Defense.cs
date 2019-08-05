using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense : MonoBehaviour {
	public int Hp = 5;
	public string currentTag;
	public void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == currentTag)
			Hp--;
	}
}
