using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractTrackable : MonoBehaviour {

	public abstract void OnTrackingFound();

	public abstract void OnTrackingLost();
}
