using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasTrackable : AbstractTrackable
{
	public override void OnTrackingFound()
	{
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        foreach (var component in canvasComponents)
            component.enabled = true;
	}
	
	public override void OnTrackingLost()
	{
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        foreach (var component in canvasComponents)
            component.enabled = false;
	}
}
