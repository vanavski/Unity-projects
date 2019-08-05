using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveGhost : MonoBehaviour
{
    public Transform endPoint;
    public Transform endPoint2;
    public float speed;
    public float rotate = 0;
    private bool point1;
    private bool point2;
    private float timer;
    private bool roaring = false;

    public Image img;
    public VoiceController vController;
    public AudioSource roar;
    public AudioClip clip;
    public AudioSource[] sources;

    void Start()
    {
        timer = 0;
        transform.Rotate(0, 180, 0);
        vController.PlayGhost();
    }

    void MoveOfGhost(Transform pos)
    {
        transform.position = Vector3.MoveTowards(transform.position, pos.position, speed * Time.deltaTime);
    }

    void RotationGhost()
    {
        timer += Time.deltaTime;
        if (timer > 2) //wait 2 seconds
        {
            var lookPos = endPoint2.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);

            rotation *= Quaternion.Euler(0, .5f, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speed);
        }
    }
    
    void Update()
    {
        if (!point1)
        {
            MoveOfGhost(endPoint);
        }
        else
        {
            MoveOfGhost(endPoint2);
            if (!roaring)
            {
                vController.PlayWithSpeaker(roar, clip);
                roaring = true;
            }
            if (Vector3.Distance(transform.position, endPoint2.position) < 0.1f)
            {
                timer += Time.deltaTime;
                var alpha = img.color;
                alpha.a = 255f;
                img.color = alpha;
                foreach(AudioSource ss in sources)
                {
                    ss.Stop();
                }
                if(timer > 2)
                {
                    Application.LoadLevel(4);
                }
            }
        }

        Debug.Log(transform.rotation.y);
        if(Vector3.Distance(transform.position, endPoint.position) < 0.1f)
        {
            RotationGhost();
            if (transform.rotation.y < 0.75)
            {
                timer = 0;
                point1 = true;
                speed = 100;
            }
        }
    }
}
