using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLabirint : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (GetComponent<Description>().text == "darkness")
            Application.LoadLevel(2);
        if (GetComponent<Description>().text == "Exit")
            Application.LoadLevel(3);
        if (GetComponent<Description>().text == "Portal" && col.tag == "Object")
            Application.LoadLevel(5);
        if (GetComponent<Description>().text == "Portal" && col.tag == "Player")
            Application.LoadLevel(4);            
    }
}
