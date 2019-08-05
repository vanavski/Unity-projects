using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitQuest : MonoBehaviour {

    public VoiceController vController;
    public GameObject Player;
    public GameObject pointToRestart;

    public GameObject[] voiceStands;

    public float timer;
    [HideInInspector]
    public bool start;
    private float timerWord = 0f;

    public GameObject Key;
    public GameObject keyPoint;
    
    public bool dungeon;
    public bool master;
    public bool ass;
    public bool we;
    public bool can;

    private bool quest;
    [HideInInspector]
    public bool exitRoomBegin;

    private bool getKey;


    // Use this for initialization
    void Start () {
        start = false;
        dungeon = false;
        master = false;
        ass = false;
        we = false;
        can = false;
        quest = false;
        exitRoomBegin = false;
        getKey = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (exitRoomBegin)
        {
            if (!vController.IsPlaying())
            {
                vController.PlayExitRoomBegin();
                if (!vController.IsPlaying() && (!vController.dungeon || !vController.master || !vController.ass || !vController.we || !vController.can))
                {
                    timerWord += Time.deltaTime;
                    switch ((int)timerWord)
                    {
                        case 0:

                            vController.PlayDungeon();

                            break;
                        case 1:

                            vController.PlayMaster();

                            break;
                        case 2:

                            vController.PlayAss();

                            break;
                        case 3:

                            vController.PlayWe();

                            break;
                        case 4:

                            vController.PlayCan();
                            exitRoomBegin = false;
                            break;
                    }
                }
            }
        }
        if (start)
        {
            timer += Time.deltaTime;
            if (dungeon && master && ass && we && can)
            {
                quest = true;
                Win();
                start = false;
            }
        }

        if (timer >= 88)
            Restart();

        vController.quest = quest;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            vController.PlayLetMeGo();
            exitRoomBegin = true;
        }
    }

    public void ActivateQuest()
    {
        if (!exitRoomBegin)
        {
            vController.AmbientStop();
            vController.PlayThemeSA();
            start = true;
        }
    }

    void Restart()
    {
        timer = 0;
        start = false;
        Player.transform.position = pointToRestart.transform.position;
        Player.transform.rotation = pointToRestart.transform.rotation;
        GetComponent<BoxCollider>().enabled = true;
        GetComponent<GetKey>().status = "";
        GetComponent<GetKey>().OpenDoorPlayer();
        vController.Stop();
        vController.themeSA = false;
        vController.AmbientPlay();

        QuestStand[] stands = FindObjectsOfType<QuestStand>();
        foreach(QuestStand stand in stands)
        {
            stand.GetComponent<BoxCollider>().enabled = true;
            stand.guy.GetComponent<DecorationObject>().enabled = true;
            stand.guy.GetComponent<ObjectController>().enabled = true;
            stand.guy.transform.position = stand.guy_standart;
            stand.stand = false;
        }
    }

    void Win()
    {
        timer = 0;
        GetComponent<GetKey>().status = "";
        GetComponent<GetKey>().OpenDoorPlayer();
        vController.PlayExitRoom();
        if (!getKey)
        {
            Key.transform.position = keyPoint.transform.position;
            Key.SetActive(true);
            getKey = true;
            var nulenie = new Vector3(keyPoint.transform.position.x, 0, keyPoint.transform.position.z);
            Key.transform.position = nulenie;
        }
    } 
}
