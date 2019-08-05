using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakenEye : MonoBehaviour {

    public int eyeCount;
    public const int finished = 4;
    public GameObject EndGame;
    public Text text;
    public GameObject camera;
    public static bool GameIsPaused = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Eye"))
                {
                    eyeCount++;
                    Destroy(hit.transform.gameObject);
                    text.text = "eyes: " + eyeCount;
                }
            }

            if (eyeCount == finished)
            {
                Pause();
                EndGame.GetComponent<Text>().text = "U WIN!!!";
                EndGame.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EndGame.GetComponent<Text>().text = "U LOSE!!!";
            Pause();
            EndGame.SetActive(true);
        }
    }

    void Pause()
    {
        EndGame.SetActive(true);
        GetComponent<CameraController>().enabled = false;
        camera.GetComponent<CameraController>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
        Time.timeScale = 0f;
        GameIsPaused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
