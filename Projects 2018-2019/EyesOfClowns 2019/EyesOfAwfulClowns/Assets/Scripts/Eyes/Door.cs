using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public GameObject door;
    public GameObject player;
    public GameObject doorUI;
    public int eyeC;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (doorUI.activeSelf)
                doorUI.SetActive(false);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Button"))
                {
                    int eyesCount = player.GetComponent<TakenEye>().eyeCount;
                    if (eyesCount >= eyeC)
                    {
                        Destroy(door);
                        Destroy(gameObject);
                    }
                    else doorUI.SetActive(true);
                }
            }
        }
    }
}
