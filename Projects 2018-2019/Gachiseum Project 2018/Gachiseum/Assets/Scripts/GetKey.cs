using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKey : MonoBehaviour
{
    public GameObject door;
    public GameObject _object;
    public VoiceController vController;

    [Header("For open/close clips")]
    public AudioClip[] clip;

    [HideInInspector]
    public bool opened;

    public string lr;
    public string status;

    public string func;

    private void Start()
    {
        if (status.Contains("Open"))
        {
            opened = true;
        } else
        {
            opened = false;
        }

        
    }

    private void Update()
    {
        if (func.Contains("OpenMainDoor"))
        {
            _object = GameObject.Find("Key(Clone)");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == _object.name)
        {
            if (func.Contains("Door"))
            {
                OpenDoor();
            }
            if (func.Contains("MainDoors"))
            {
                OpenMainDoor();
            }
        }
        if (func.Contains("Destroy"))
        {
            DestroyDoor();
        }
    }

    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Debug.Log("OPEN");
    //        if (!opened)
    //        {
    //            if (lr.Contains("L"))
    //            {
    //                door.Play("OpenDoor1");
    //                opened = true;
    //            }
    //            if (lr.Contains("R"))
    //            {
    //                door.Play("OpenDoor");
    //                opened = true;
    //            }
    //        }
    //        Debug.Log(door.isPlaying + " : " + opened);
    //        //opened = true;
    //    }
    //}

    void DestroyDoor()
    {
        bool right = false;
        Debug.Log("YES");
        switch (status)
        {
            case "M16":
                if (status.Equals(_object.gameObject.name)) {
                    vController.PlayS1();
                    right = true;
                }
                break;
            case "Aug":
                if (status.Equals(_object.gameObject.name))
                {
                    vController.PlayS2();
                    right = true;
                }
                break;
            case "Awp":
                if (status.Equals(_object.gameObject.name))
                {
                    vController.PlayS4();
                    right = true;
                }
                break;
            case "AK-47":
                if (status.Equals(_object.gameObject.name))
                {
                    vController.PlayS5();
                    right = true;
                }
                break;
            case "Pistol":
                if (status.Equals(_object.gameObject.name))
                {
                    vController.PlayS3();
                    right = true;
                }
                break;
        }
        if (right)
        {
            Destroy(door);
            _object.transform.position = transform.position;
            _object.transform.rotation = transform.rotation;
            _object.transform.Rotate(0, -90, 0);
            if (_object.GetComponent<ObjectController>() != null)
                _object.GetComponent<ObjectController>().enabled = false;
            _object.GetComponent<DecorationObject>().enabled = false;
            Destroy(_object.GetComponent<Rigidbody>());
        } else
        {
            vController.PlayWithSpeaker(_object.GetComponent<AudioSource>(), clip[0]);
        }
    }

    void OpenDoor()
    {
        var door_anim = door.GetComponent<Animation>();
        _object.transform.position = transform.position;
        if (_object.GetComponent<ObjectController>() != null)
            _object.GetComponent<ObjectController>().enabled = false;
        if(_object.GetComponent<Rigidbody>() != null)
            _object.GetComponent<Rigidbody>().useGravity = true;

        if (lr.Contains("L"))
        {
           
            if (!opened)
            {
                door_anim.enabled = true;
                door_anim.Play("OpenDoor1");
                if (door.GetComponent<AudioSource>() != null)
                    vController.PlayWithSpeaker(door.GetComponent<AudioSource>(), clip[0]);
                opened = true;
            }
            else
            {
                door_anim.enabled = true;
                door_anim.Play("CloseDoor1");
                if (door.GetComponent<AudioSource>() != null)
                    vController.PlayWithSpeaker(door.GetComponent<AudioSource>(), clip[1]);
                GetComponent<BoxCollider>().enabled = false;
                opened = false;
            }
        }
        if (lr.Contains("R"))
        {
            if (!opened)
            {
                door_anim.enabled = true;
                door_anim.Play("OpenDoor");
                if (door.GetComponent<AudioSource>() != null)
                    vController.PlayWithSpeaker(door.GetComponent<AudioSource>(), clip[0]);
                opened = true;
            }
            //if (opened)
            //{
            //    door.enabled = true;
            //    door.Play("CloseDoor");
            //    opened = false;
            //}
        }
    }

    public void OpenDoorPlayer()
    {
        var door_anim = door.GetComponent<Animation>();
        if (lr.Contains("L"))
        {

            if (!opened)
            {
                door_anim.enabled = true;
                door_anim.Play("OpenDoor1");
                if(door.GetComponent<AudioSource>() != null)
                    vController.PlayWithSpeaker(door.GetComponent<AudioSource>(), clip[0]);
                opened = true;
            }
            else
            {
                door_anim.enabled = true;
                door_anim.Play("CloseDoor1");
                if (door.GetComponent<AudioSource>() != null)
                    vController.PlayWithSpeaker(door.GetComponent<AudioSource>(), clip[1]);
                GetComponent<BoxCollider>().enabled = false;
                opened = false;
            }
        }
        if (lr.Contains("R"))
        {
            if (!opened)
            {
                door_anim.enabled = true;
                door_anim.Play("OpenDoor");
                if (door.GetComponent<AudioSource>() != null)
                    vController.PlayWithSpeaker(door.GetComponent<AudioSource>(), clip[0]);
                opened = true;
            }
            //if (opened)
            //{
            //    door.enabled = true;
            //    door.Play("CloseDoor");
            //    opened = false;
            //}
        }
    }

    public void OpenMainDoor()
    {
        var door_anim = door.GetComponent<Animation>();
        door_anim.enabled = true;
        door_anim.Play("MainDoor");
        vController.PlayNoEnd01();
        Destroy(this.gameObject);
        Destroy(_object);
    }
}
