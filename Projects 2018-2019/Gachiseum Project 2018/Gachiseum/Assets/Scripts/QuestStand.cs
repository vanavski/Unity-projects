using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestStand : MonoBehaviour {

    public ExitQuest eq;

    public GameObject guy;
    public Vector3 guy_standart;
    public string tag;

    [HideInInspector]
    public bool stand;
    private Vector3 a;
    private Vector3 b;
    float speed = 0.3f;
    float delta = 0.5f;
    float y = 0;

    private void Start()
    {
        guy_standart = guy.transform.position;
        a = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        b = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        stand = false;
        y = guy.transform.position.y;
    }

    private void Update()
    {
        if (stand)
        {
            float y = Mathf.PingPong(speed * Time.time, delta);

            Debug.Log(y);
            Vector3 pos = new Vector3(guy.transform.position.x, y + 1, guy.transform.position.z);
            guy.transform.position = pos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (eq.start)
        {
            if (other.gameObject.name == guy.name)
            {
                stand = true;
                guy.transform.position = new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z);
                guy.transform.rotation = transform.rotation;
                if (guy.GetComponent<ObjectController>() != null)
                    guy.GetComponent<ObjectController>().enabled = false;
                guy.GetComponent<DecorationObject>().enabled = false;

                GetComponent<BoxCollider>().enabled = false;

                switch (tag)
                {
                    case "Dungeon":
                        eq.dungeon = true;
                        break;
                    case "Master":
                        eq.master = true;
                        break;
                    case "Ass":
                        eq.ass = true;
                        break;
                    case "We":
                        eq.we = true;
                        break;
                    case "Can":
                        eq.can = true;
                        break;
                }
            }
        }
    }
}
