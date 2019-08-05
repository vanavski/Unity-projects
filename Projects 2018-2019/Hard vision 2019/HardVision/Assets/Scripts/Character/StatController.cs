using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StatController
{
    [SerializeField]
    private float baseValue;
    private List<float> modifiers = new List<float>();

    public float GetValue()
    {
        var finalValue = baseValue;
        modifiers.ForEach(m => finalValue += m);
        return finalValue;
    }

    public void AddModifier(float modifier)
    {
        if (modifier != 0)
            modifiers.Add(modifier);
    }

    public void RemoveModifier(float modifier)
    {
        if (modifier != 0)
            modifiers.Remove(modifier);
    }
}