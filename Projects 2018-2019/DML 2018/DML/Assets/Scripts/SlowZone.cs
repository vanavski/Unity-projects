using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowZone : MonoBehaviour
{
    [SerializeField]
	  private float slowingSpeed = 1f;
    
    void OnTriggerStay(Collider other)
    {
		    Rigidbody r = other.GetComponent<Rigidbody>();
		    if (r != null) 
        {
			      r.velocity = Vector3.MoveTowards(r.velocity, Vector3.zero, slowingSpeed * Time.deltaTime);
		    }
    }
}
