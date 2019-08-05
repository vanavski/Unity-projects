using UnityEngine;

public class PlayerInfo : MonoBehaviour
{

    public static Transform player;

    void Start()
    {
        FindPlayer();
    }

    public static void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
}