using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendererTrackable : AbstractTrackable 
{
	public override void OnTrackingFound()
	{
        var rendererComponents = GetComponentsInChildren<Renderer>(true);

		foreach (var component in rendererComponents)
            component.enabled = true;
	}

	public override void OnTrackingLost() 
	{
        var rendererComponents = GetComponentsInChildren<Renderer>(true);

        foreach (var component in rendererComponents)
            component.enabled = false;
	}
}
