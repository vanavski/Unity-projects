using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        Application.LoadLevel(1);
    }

    public void SavedGame()
    {

    }

    public void Archive()
    {

    }

    public void Exit()
    {
        Application.Quit();
    }
}
