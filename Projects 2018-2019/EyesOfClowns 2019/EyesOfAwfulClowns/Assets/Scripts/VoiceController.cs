using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceController : MonoBehaviour {

    public AudioClip[] voices;
    public GameObject[] speakers;
    public GameObject[] quest_speakers;

    private AudioSource[] sources;

    public AudioSource ambientGachi;
    

    private int i;

    private float time;

    public bool start;
    public bool ending;
    public bool cutS;
    private bool ambient;
    private bool vstavka01;
    private bool vstavka02;
    private bool ak47;
    private bool awp;
    private bool exitroom;
    private bool final;
    private bool gachi01;
    private bool gachi02;
    private bool pistol;
    private bool toilet;
    private bool uzi;
    private bool exitRoomB = false;
    private bool exitRoomL = false;
    private bool ezpz = false;
    private bool letmego = false;
    private bool track = false;
    private bool vstavka03 = false;
    private bool water = false;
    private bool noEnd01 = false;
    private bool awpMech = false;
    private bool weapon = false;
    private bool m16 = false;
    private bool s1 = false;
    private bool s2 = false;
    private bool s4 = false;
    private bool s5 = false;
    private bool f2 = false;
    private bool s3 = false;
    private bool begin02 = false;
    private bool end01 = false;
    private bool end02 = false;


    public bool lab;

    [HideInInspector]
    public bool quest;

    [HideInInspector]
    public bool dungeon;
    [HideInInspector]
    public bool master;
    [HideInInspector]
    public bool ass;
    [HideInInspector]
    public bool we;
    [HideInInspector]
    public bool can;
    [HideInInspector]
    public bool themeSA;
    

    public int coun;


    // Use this for initialization
    void Start () {
        //start = false;
        ambient = false;
        vstavka01 = false;
        vstavka02 = false;
        ak47 = false;
        awp = false;
        exitroom = false;
        final = false;
        gachi01 = false;
        gachi02 = false;
        pistol = false;
        toilet = false;
        uzi = false;

        dungeon = false;
        master = false;
        ass = false;
        we = false;
        can = false;
        themeSA = false;

        //eq = FindObjectOfType<ExitQuest>();
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (!IsPlaying())
        {
            if (start)
            {
                AmbientPlay();
                if (lab) 
                PlayBegin02();
            }
            if(time >= 180 && !vstavka01 && !s4)
            {
                PlayVsavka01();
            }
            if(time >= 240 && !vstavka02 && !s4)
            {
                PlayVsavka02();
            }
            if(time >= 360 && !vstavka03 && !s4)
            {
                PlayVstavka03();
            }
        }
	}

    public void PlayGhost()
    {
        if (cutS)
        {
            foreach (GameObject source in speakers)
            {
                var ss = source.GetComponent<AudioSource>();
                ss.clip = voices[0];
                ss.Play();
                cutS = false;
            }
        }
    }

    public bool IsPlaying()
    {
        return speakers[0].GetComponent<AudioSource>().isPlaying;
    }

    public void PlayStart01()
    {
        foreach(GameObject source in speakers)
        {
            var ss = source.GetComponent<AudioSource>();
            ss.clip = voices[0];
            ss.Play();
            start = true;
        }
    }

    public void AmbientPlay()
    {
        if (!ambient & !cutS)
        {
            ambientGachi.Play();
            ambient = true;
        }
    }

    public void AmbientStop()
    {
        ambient = false;
        ambientGachi.Stop();
    }

    public void PlayVsavka01()
    {
        foreach(GameObject source in speakers)
        {
            var ss = source.GetComponent<AudioSource>();
            ss.clip = voices[1];
            ss.Play();
            vstavka01 = true;
        }
    }

    public void PlayVsavka02()
    {
        foreach (GameObject source in speakers)
        {
            var ss = source.GetComponent<AudioSource>();
            ss.clip = voices[2];
            ss.Play();
            vstavka02 = true;
        }
    }

    public void PlayAk47()
    {
        if (!ak47 && start)
        {
            Debug.Log(ak47);
            foreach (GameObject source in speakers)
            {
                var ss = source.GetComponent<AudioSource>();
                ss.clip = voices[3];
                ss.Play();
                ak47 = true;
            }
        }
    }

    public void PlayAWP()
    {
        if (!awp && start)
        {
            foreach (GameObject source in speakers)
            {
                var ss = source.GetComponent<AudioSource>();
                ss.clip = voices[4];
                ss.Play();
                awp = true;
            }
        }
    }

    public void PlayExitRoom()
    {
        if (!exitroom && start)
        {
            foreach (GameObject source in speakers)
            {
                var ss = source.GetComponent<AudioSource>();
                ss.clip = voices[5];
                ss.Play();
                exitroom = true;
            }
        }
    }

    public void PlayFinal()
    {
        if (!final && start)
        {
            foreach (GameObject source in speakers)
            {
                var ss = source.GetComponent<AudioSource>();
                ss.clip = voices[6];
                ss.Play();
                final = true;
            }
        }
    }

    public void PlayGachi01()
    {
        if (!gachi01 && start)
        {
            foreach (GameObject source in speakers)
            {
                var ss = source.GetComponent<AudioSource>();
                ss.clip = voices[7];
                ss.Play();
                gachi01 = true;
            }
        }
    }

    public void PlayGachi02()
    {
        if (!gachi02 && start)
        {
            foreach (GameObject source in speakers)
            {
                var ss = source.GetComponent<AudioSource>();
                ss.clip = voices[8];
                ss.Play();
                gachi02 = true;
            }
        }
    }

    public void PlayPistol()
    {
        if (!pistol && start)
        {
            foreach (GameObject source in speakers)
            {
                var ss = source.GetComponent<AudioSource>();
                ss.clip = voices[9];
                ss.Play();
                pistol = true;
            }
        }
    }

    public void PlayToilet()
    {
        if (!toilet && start)
        {
            foreach (GameObject source in speakers)
            {
                var ss = source.GetComponent<AudioSource>();
                ss.clip = voices[10];
                ss.Play();
                toilet = true;
            }
        }
    }

    public void PlayUzi()
    {
        if (!uzi && start)
        {
            foreach (GameObject source in speakers)
            {
                var ss = source.GetComponent<AudioSource>();
                ss.clip = voices[11];
                ss.Play();
                uzi = true;
            }
        }
    }

    public void PlayDungeon()
    {
        if(start && !quest && !dungeon)
        {
            var qs = quest_speakers[0].GetComponent<AudioSource>();
            qs.clip = voices[12];
            if (!qs.isPlaying)
            {
                qs.Play();
                dungeon = true;
            }
            
        }
    }

    public void PlayMaster()
    {
        if (start && !quest && !master)
        {
            var qs = quest_speakers[1].GetComponent<AudioSource>();
            qs.clip = voices[13];
            if (!qs.isPlaying)
            {
                qs.Play();
                master = true;
            }
                
        }
    }

    public void PlayAss()
    {
        if (start && !quest && !ass)
        {
            var qs = quest_speakers[2].GetComponent<AudioSource>();
            qs.clip = voices[14];
            if (!qs.isPlaying)
            {
                qs.Play();
                ass = true;
            }
                
        }
    }

    public void PlayWe()
    {
        if (start && !quest && !we)
        {
            var qs = quest_speakers[3].GetComponent<AudioSource>();
            qs.clip = voices[15];
            if (!qs.isPlaying)
            {
                qs.Play();
                we = true;
            }
                
        }
    }

    public void PlayCan()
    {
        if (start && !quest && !can)
        {
            var qs = quest_speakers[4].GetComponent<AudioSource>();
            qs.clip = voices[16];
            if (!qs.isPlaying)
            {
                qs.Play();
                can = true;
            }
                
        }
    }

    public void PlayThemeSA()
    {
        if(!quest && start && !themeSA)
        {
            foreach (GameObject source in speakers)
            {
                var ss = source.GetComponent<AudioSource>();
                ss.clip = voices[17];
                ss.Play();
                themeSA = true;
            }
        }
    }

    public void Stop()
    {
        foreach (GameObject source in speakers)
        {
            var ss = source.GetComponent<AudioSource>();
            ss.Stop();
        }
    }

    public void PlayExitRoomBegin()
    {
        if(start && !exitRoomB)
        {
            foreach (GameObject source in speakers)
            {
                var ss = source.GetComponent<AudioSource>();
                ss.clip = voices[18];
                ss.Play();
                exitRoomB = true;
            }
        }
    }

    public void PlayExitRoomLose()
    {
        if(start && !exitRoomL)
        {
            foreach (GameObject source in speakers)
            {
                var ss = source.GetComponent<AudioSource>();
                ss.clip = voices[19];
                ss.Play();
                exitRoomL = true;
            }
        }
    }

    public void PlayEzPz()
    {
        if(start && !ezpz)
        {
            foreach (GameObject source in speakers)
            {
                var ss = source.GetComponent<AudioSource>();
                ss.clip = voices[20];
                ss.Play();
                ezpz = true;
            }
        }
    }

    public void PlayLetMeGo()
    {
        if(start && !letmego)
        {
            foreach (GameObject source in speakers)
            {
                var ss = source.GetComponent<AudioSource>();
                ss.clip = voices[21];
                ss.Play();
                letmego = true;
            }
        }
    }

    public void PlayTrack()
    {
        if (start && !track)
        {
            foreach (GameObject source in speakers)
            {
                var ss = source.GetComponent<AudioSource>();
                ss.clip = voices[22];
                ss.Play();
                track = true;
            }
        }
    }

    public void PlayVstavka03()
    {
        if(start && !vstavka03)
        {
            foreach (GameObject source in speakers)
            {
                var ss = source.GetComponent<AudioSource>();
                ss.clip = voices[23];
                ss.Play();
                vstavka03 = true;
            }

        }
    }

    

    public void PlayWater()
    {
        if(start && !water)
        {
            foreach (GameObject source in speakers)
            {
                var ss = source.GetComponent<AudioSource>();
                ss.clip = voices[24];
                ss.Play();
                water = true;
            }
        }
    } 

    public void PlayNoEnd01()
    {
        if(start && !noEnd01)
        {
            foreach (GameObject source in speakers)
            {
                var ss = source.GetComponent<AudioSource>();
                ss.clip = voices[25];
                ss.Play();
                noEnd01 = true;
            }
        }
    }

    public void PlayAWPMechanic()
    {
        if(start && !awpMech)
        {
            foreach (GameObject source in speakers)
            {
                var ss = source.GetComponent<AudioSource>();
                ss.clip = voices[26];
                ss.Play();
                awpMech = true;
            }
        }
    }

    public void PlayWeapon()
    {
        if(start && !weapon)
        {
            foreach (GameObject source in speakers)
            {
                var ss = source.GetComponent<AudioSource>();
                ss.clip = voices[27];
                ss.Play();
                weapon = true;
            }
        }
    }

    // 28 and 29 - open/close door;

    public void PlayWithSpeaker(AudioSource speaker, AudioClip clip)
    {
        speaker.clip = clip;
        speaker.Play();
    }

    // 30 - button

    public void PlayButton(GameObject button)
    {
        var speaker = button.GetComponent<AudioSource>();
        speaker.clip = voices[30];
        speaker.Play();
    }

    public void PlayM16()
    {
        if (start && !m16)
        {
            foreach (GameObject source in speakers)
            {
                var ss = source.GetComponent<AudioSource>();
                ss.clip = voices[0];
                ss.Play();
                m16 = true;
            }
        }
    }

    public void PlayS1()
    {
        if (start && !s1)
        {
            foreach (GameObject source in speakers)
            {
                var ss = source.GetComponent<AudioSource>();
                ss.clip = voices[3];
                ss.Play();
                s1 = true;
            }
        }
    } 

    public void PlayS2()
    {
        if(start && !s2)
        {
            foreach (GameObject source in speakers)
            {
                var ss = source.GetComponent<AudioSource>();
                ss.clip = voices[4];
                ss.Play();
                s2 = true;
            }
        }
    }
    public void PlayS4()
    {
        if(start && !s4)
        {
            foreach (GameObject source in speakers)
            {
                var ss = source.GetComponent<AudioSource>();
                ss.clip = voices[5];
                ss.Play();
                s4 = true;
            }
        }
    }

    public void PlayS5()
    {
        if (start && !s5)
        {
            foreach (GameObject source in speakers)
            {
                var ss = source.GetComponent<AudioSource>();
                ss.clip = voices[6];
                ss.Play();
                s5 = true;
            }
        }
    }

    public void PlayF2()
    {
        if (start && !f2)
        {
            foreach (GameObject source in speakers)
            {
                var ss = source.GetComponent<AudioSource>();
                ss.clip = voices[7];
                ss.Play();
                f2 = true;
            }
        }
    }

    public void PlayS3()
    {
        if(start && !s3)
        {
            foreach (GameObject source in speakers)
            {
                var ss = source.GetComponent<AudioSource>();
                ss.clip = voices[8];
                ss.Play();
                s3 = true;
            }
        }
    }

    public void PlayBegin02()
    {
        if (start & !begin02 & lab)
        {
            foreach (GameObject source in speakers)
            {
                var ss = source.GetComponent<AudioSource>();
                ss.clip = voices[coun];
                ss.Play();
                begin02 = true;
            }
        }
    }

    public void PlayEnd01()
    {
        if (start && !end01 && ending)
        {
            foreach (GameObject source in speakers)
            {
                var ss = source.GetComponent<AudioSource>();
                ss.clip = voices[0];
                ss.Play();
                end01 = true;
            }
        }
    }

    public void PlayEnd02()
    {
        if (start && !end02 && ending)
        {
            foreach (GameObject source in speakers)
            {
                var ss = source.GetComponent<AudioSource>();
                ss.clip = voices[1];
                ss.Play();
                end02 = true;
            }
        }
    }
}
