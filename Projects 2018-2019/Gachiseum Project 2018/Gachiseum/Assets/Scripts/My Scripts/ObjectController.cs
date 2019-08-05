using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour {

    public GameObject playerTouch;

    private bool take;
    private bool onHand;

    public VoiceController vController;

    [TextArea]
    public string info;

    public string sound;

    public string Description()
    {
        if(playerTouch == null)
        {
            playerTouch = GameObject.FindGameObjectWithTag("Touch");
        }
        return info;
    }
    
	void Update () {
		if(take)
        {
            if (Input.GetMouseButton(0))
            {
                onHand = true;
                GetComponent<Rigidbody>().useGravity = false;
                var dest = new Vector3(playerTouch.transform.position.x, playerTouch.transform.position.y, playerTouch.transform.position.z);
                transform.position = dest;
                //Debug.Log("Mew");
            }            
        }

        take = false;
        
        if (Input.GetMouseButtonUp(0))
        {
            onHand = false;
            GetComponent<Rigidbody>().useGravity = true;
            Deactivate();
        }

        if (onHand)
        {
            PlaySound();
        } else
        {
            RefreshSound();
        }
    }

    //private void OnMouseDrag()
    //{
    //    GetComponent<Rigidbody>().useGravity = false;
    //    var dest = new Vector3(playerTouch.transform.position.x, playerTouch.transform.position.y, playerTouch.transform.position.z);
    //    transform.position = dest;
    //}

    //private void OnMouseUp()
    //{
    //    transform.parent = null;
    //    GetComponent<Rigidbody>().useGravity = true;
    //}

    public void Activate(GameObject p)
    {
        take = true;
        playerTouch = p;
    }

    public void Deactivate()
    {
        take = false;
        playerTouch = null;
    }

    public void PlaySound()
    {
        switch (sound)
        {
            case "Pistol":
                vController.PlayPistol();
                break;
            case "Awp":
                vController.PlayAWP();
                break;
            case "Dungeon":
                if (FindObjectOfType<ExitQuest>().start)
                {
                    vController.PlayDungeon();
                }
                break;
            case "Master":
                if (FindObjectOfType<ExitQuest>().start)
                {
                    vController.PlayMaster();
                }
                break;
            case "Ass":
                if (FindObjectOfType<ExitQuest>().start)
                {
                    vController.PlayAss();
                }
                break;
            case "We":
                if (FindObjectOfType<ExitQuest>().start)
                {
                    vController.PlayWe();
                }
                break;
            case "Can":
                if (FindObjectOfType<ExitQuest>().start)
                {
                    vController.PlayCan();
                }
                break;
            case "Uzi":
                vController.PlayUzi();
                break;
            case "Weapon":
                vController.PlayWeapon();
                break;
            case "AwpMech":
                vController.PlayAWPMechanic();
                break;
            case "M16":
                vController.PlayM16();
                break;
            case "End02":
                vController.PlayEnd02();
                break;
            
        }

        //if (sound.Contains("Pistol"))
        //{
        //    vController.PlayPistol();
        //}
        //if (sound.Contains("Awp"))
        //{
        //    vController.PlayAWP();
        //}
        //if (sound.Contains("Dungeon"))
        //{
        //    vController.PlayDungeon();
        //}
        //if (sound.Contains("Master"))
        //{
        //    vController.PlayMaster();
        //}
        //if (sound.Contains("Ass"))
        //{
        //    vController.PlayAss();
        //}
        //if (sound.Contains("We"))
        //{
        //    vController.PlayWe();
        //}
        //if (sound.Contains("Can"))
        //{
        //    vController.PlayCan();
        //}

    }

    public void RefreshSound()
    {
        if (FindObjectOfType<ExitQuest>() != null)
        {
            Debug.Log(FindObjectOfType<ExitQuest>().start);
            if (FindObjectOfType<ExitQuest>().start)
            {
                switch (sound)
                {
                    case "Dungeon":
                        vController.dungeon = false;
                        break;
                    case "Master":
                        vController.master = false;
                        break;
                    case "Ass":
                        vController.ass = false;
                        break;
                    case "We":
                        vController.we = false;
                        break;
                    case "Can":
                        vController.can = false;
                        break;
                }
            }
        }
    }
}
