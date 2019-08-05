using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {

    public float player_Here;
    public GameObject playerTouch;

    enum Active
    {
        YES,
        NO
    }

    public GameObject[] objs;

    private bool button;
    private bool stand;
    [HideInInspector]
    public bool done;

    [TextArea]
    public string description;

    public string[] button_func;

    [Header("VOICE")]
    public VoiceController vController;

    [Header("FOR STANDS")]
    public Image img;
    public Text info;

    private void Start()
    {
        done = false;
        player_Here = 1;
        playerTouch = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        switch ((int)player_Here)
        {
            case (int)Active.YES:
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (button)
                    {
                        Function();
                    }
                    if (stand)
                    {
                        info.text = description;
                        info.enabled = true;
                        img.enabled = true;
                        
                    }
                }
                break;
            case (int)Active.NO:

                break;
            
        }

        //Debug.Log(this.gameObject.name + ": " + Vector3.Distance(transform.position, playerTouch.transform.position));

        if (stand)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Vector3.Distance(transform.position, playerTouch.transform.position) > 4f)
            {
                info.enabled = false;
                img.enabled = false;
                stand = false;
            }
        }

        if ((int)player_Here != 0)
        {
            player_Here += Time.deltaTime;
            if (player_Here > 10)
            {
                player_Here = 1;
            }
        } else
        {
            var timer = player_Here;
            timer += Time.time;
            if(timer > 1)
            {
                player_Here = 1;
            }
        }
        
        
    }

    public string Description()
    {
        return description;
    }

    public void Activate_Stand(int p)
    {
        button = false;
        stand = true;
        player_Here = p;
    }

    public void Activate_Button(int p)
    {
        button = true;
        stand = false;
        player_Here = p;
    }

    public void Deactivate(int p)
    {
        button = false;
        stand = false;
        player_Here = p;
    }

    private void Function()
    {
        if(GetComponent<AudioSource>() != null)
        vController.PlayButton(this.gameObject);
        foreach (string func in button_func)
        {
            // wait | fast
            string _bool = func.Substring(0, 4);
            string _func = func.Substring(4);

            Debug.Log(_bool + " " + _func);
            if (_bool.Contains("wait"))
            {
                while (!done)
                {
                    switch (_func)
                    {
                        case "LightButton":
                            foreach (GameObject obj in objs)
                            {
                                //if (obj.active)
                                //    obj.SetActive(false);
                                //else
                                //    obj.SetActive(true);
                                var spot = obj.GetComponent<LightController>();

                                var light = obj.GetComponent<Light>();

                                if (spot.play)
                                {
                                    light.intensity = 8.5f;

                                    spot.TurnOn();
                                }
                                done = true;
                            }
                            break;
                        case "LightButtonTimer":

                            StartCoroutine(Timer());

                            break;
                        case "OpenDoorButton":
                            done = true;
                            break;
                        case "SoundButton":
                            done = true;
                            break;
                        case "SpecialScript":
                            foreach (GameObject obj in objs)
                            {
                                obj.GetComponent<StartGame>().Activate();
                            }
                            done = true;
                            break;
                        case "Play01":
                            vController.PlayStart01();
                            done = true;
                            break;
                        default:
                            if (player_Here == 0)
                                playerTouch.GetComponentInChildren<InteractivePlayer>().SendMsg("Nothing happened");
                            done = true;
                            break;
                    }
                }
            } else
            {
                switch (_func)
                {
                    case "LightButton":
                        foreach (GameObject obj in objs)
                        {
                            //if (obj.active)
                            //    obj.SetActive(false);
                            //else
                            //    obj.SetActive(true);
                            var spot = obj.GetComponent<LightController>();

                            var light = obj.GetComponent<Light>();

                            if (spot.play)
                            {
                                light.intensity = 8.5f;

                                spot.TurnOn();
                            }
                        }
                        break;
                    case "LightButtonTimer":

                        StartCoroutine(Timer());

                        break;
                    case "OpenDoorButton":
                        break;
                    case "QuestButton":
                        foreach(GameObject obj in objs)
                        {
                            obj.GetComponent<ExitQuest>().ActivateQuest();
                        }
                        break;
                    case "SpecialScript":
                        foreach (GameObject obj in objs)
                        {
                            obj.GetComponent<StartGame>().Activate();
                        }

                        break;
                    case "Play00":
                        vController.PlayStart01();
                        break;
                    case "Play04":
                        vController.PlayAWP();
                        break;
                    case "Play07":
                        vController.PlayGachi01();
                        break;
                    case "Play08":
                       vController.PlayGachi02();
                        break;
                    case "Play22":
                        vController.PlayTrack();
                        break;
                    case "Play24":
                        vController.PlayWater();
                        break;
                    default:
                        if (player_Here == 0)
                            playerTouch.GetComponentInChildren<InteractivePlayer>().SendMsg("Nothing happened");
                        break;
                }
            }
            
        }
    }

    IEnumerator Timer()
    {
        foreach (GameObject obj in objs)
        {
            var spot = obj.GetComponent<LightController>();

            var light = obj.GetComponent<Light>();
            if (spot.play)
            {
                light.intensity = 8.5f;

                spot.TurnOn();
            }
            yield return new WaitForSeconds(1);
        }
    }
}
