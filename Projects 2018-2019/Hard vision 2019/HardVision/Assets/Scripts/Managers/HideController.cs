using UnityEngine;

public class HideController : MonoBehaviour
{
    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}