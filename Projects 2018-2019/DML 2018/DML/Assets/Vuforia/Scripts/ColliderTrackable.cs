using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrackable : AbstractTrackable
{
	public override void OnTrackingFound()
	{
        var colliderComponents = GetComponentsInChildren<Collider>(true);

		foreach (var component in colliderComponents)
            component.enabled = true;
	}

	public override void OnTrackingLost()
	{
        var colliderComponents = GetComponentsInChildren<Collider>(true);

        foreach (var component in colliderComponents)
            component.enabled = false;
	}
}
