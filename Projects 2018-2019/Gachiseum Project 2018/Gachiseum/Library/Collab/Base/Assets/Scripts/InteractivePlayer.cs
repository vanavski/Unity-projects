using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractivePlayer : MonoBehaviour
{
    public string _collision;
    public Text description;
    public Text info_text;

    public GameObject playerTouch;
    private Vector3 point;

    public GameObject player;

    private Vector3 fwd;
    public float messageTime;
    private bool startTimer;

    private float max_dist = 3f;

    private void Start()
    {
        startTimer = false;
        point = new Vector3(0,0,1);
        description.enabled = false;
        //RaycastHit hit;
    }

    private void Update()
    {
        fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        //Debug.DrawLine(transform.position, s.transform.position);


        if (Physics.Raycast(transform.position, fwd, out hit))
            Physics.IgnoreCollision(hit.collider, player.GetComponent<Collider>(), true);
            HitSomething(hit.collider, hit.distance);

        if (startTimer)
        {
            messageTime -= Time.deltaTime;
            Debug.Log(messageTime);
            if(messageTime <= 0)
            {
                messageTime = 1;
                startTimer = false;
                info_text.enabled = false;
            }
        }


    }

    private void HitSomething(Collider hit, float dist)
    {
        _collision = hit.transform.tag;
        if (dist < max_dist)
        {
            switch (_collision)
            {
                case "Pistol":
                    var pistol = hit.gameObject.GetComponent<ObjectController>();
                    description.text = pistol.Description();
                    pistol.Activate(playerTouch);
                    break;
                case "Awp":
                    var awp = hit.gameObject.GetComponent<ObjectController>();
                    description.text = awp.Description();
                    awp.Activate(playerTouch);
                    break;
                case "Object":
                    var obj = hit.gameObject.GetComponent<ObjectController>();
                    description.text = obj.Description();
                    obj.Activate(playerTouch);
                    break;

                case "Button":
                    var button = hit.gameObject.GetComponent<ButtonController>();
                    description.text = button.Description();

                    //SCRIPT OF BUTTON


                    button.Activate_Button(0);

                    break;

                case "Stand":
                    var stand = hit.gameObject.GetComponent<ButtonController>();
                    description.text = stand.Description();


                    stand.Activate_Stand(0);

                    break;
                default:
                    description.text = "";
                    break;
            }
            description.enabled = true;
        }
        else
        {
            switch (_collision)
            {
                case "Object":
                    var obj = hit.gameObject.GetComponent<ObjectController>();
                    obj.Deactivate();
                    break;

                case "Button":
                    var button = hit.gameObject.GetComponent<ButtonController>();
                    button.Deactivate(1);

                    break;

                case "Stand":
                    var stand = hit.gameObject.GetComponent<ButtonController>();
                    stand.Deactivate(1);

                    break;
                default:
                    description.text = "";
                    break;
            }
            description.enabled = false;
        }
    }

    //private void OnTriggerExit(Collider other)
    //{

    //    description.enabled = false;
    //    switch (other.gameObject.tag)
    //    {
    //        case "Object":
    //            var obj = other.gameObject.GetComponent<ObjectController>();
    //            obj.Deactivate();
    //            break;
    //        case "Button":
    //            //SCRIPT OF BUTTON
    //            var button = other.gameObject.GetComponent<ButtonController>();
    //            button.Deactivate();
    //            break;
    //        case "Stand":
    //            //Deactivate
    //            var stand = other.gameObject.GetComponent<ButtonController>();
    //            stand.Deactivate();
    //            break;
    //    }
    //}
    

    public void SendMsg(string text)
    {
        info_text.text = "Nothing happened";
        info_text.enabled = true;
        startTimer = true;
    }

    //public void PlayMusic()
    //{
    //    musicSource.Play();
    //}
}
