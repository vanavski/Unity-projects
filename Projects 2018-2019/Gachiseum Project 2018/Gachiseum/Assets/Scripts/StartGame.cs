using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

    public GameObject[] lights_timer;
    public GameObject[] lights;
    public GameObject[] lightsx5;

    public VoiceController vController;
    private bool play01;

    private bool start;
    private bool timer;

    [HideInInspector]
    public bool done;

	// Use this for initialization
	void Start () {
        start = false;
        timer = false;
        done = false;
        play01 = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (start)
        {
            StartCoroutine(Timer());

            if (!timer)
            {
                foreach (GameObject light in lights)
                {
                    var spot = light.GetComponent<LightController>();

                    var _light = light.GetComponent<Light>();

                    if (spot.play)
                    {
                        _light.intensity = 1f;

                        spot.TurnOn();
                    }
                }
                foreach (GameObject light in lightsx5)
                {
                    var spot = light.GetComponent<LightController>();

                    var _light = light.GetComponent<Light>();

                    if (spot.play)
                    {
                        _light.intensity = 5f;

                        spot.TurnOn();
                    }
                }
                Play();
            }
        }
	}

    public void Activate()
    {
        start = true;
        timer = true;
    }

    IEnumerator Timer()
    {
        while (timer)
        {
            foreach (GameObject light in lights_timer)
            {
                var spot = light.GetComponent<LightController>();

                var _light = light.GetComponent<Light>();
                if (spot.play)
                {
                    _light.intensity = 8.5f;

                    spot.TurnOn();
                }
                yield return new WaitForSeconds(1);
            }
            timer = false;
        }
        done = true;
    }

    void Done()
    {
        var butts = GameObject.FindGameObjectsWithTag("Button");
        foreach(GameObject butt in butts)
        {
            butt.GetComponent<ButtonController>().done = true;
        }
    }

    void Play()
    {
        if (!play01)
        {
            vController.PlayStart01();
            play01 = true;
        }

    }
}
