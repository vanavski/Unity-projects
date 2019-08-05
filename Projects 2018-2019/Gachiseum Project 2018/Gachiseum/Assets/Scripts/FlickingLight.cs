using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickingLight : MonoBehaviour {

    public float constantIntens;
    public float inten;
    private float TimeDown;
    private Light light;
    void Start()
    {
        TimeDown = 1.0f;
        light = gameObject.GetComponent<Light>();
    }

    void FixedUpdate()
    {

        if (light.intensity != constantIntens) light.intensity = constantIntens;

        if (TimeDown > 0) TimeDown -= Time.deltaTime;

        if (TimeDown < 0) TimeDown = 0;

        if (TimeDown == 0)
        {
            inten = Random.Range(0f, 0.4f);
            light.intensity = inten;
            TimeDown = Random.Range(0.2f, 0.6f);
        }
    }
}
