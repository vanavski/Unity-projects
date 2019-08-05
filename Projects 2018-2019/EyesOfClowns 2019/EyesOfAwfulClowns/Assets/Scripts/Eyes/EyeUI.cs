using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeUI : MonoBehaviour {

    public GameObject eyeCount;

    public int GetEyesCount()
    {
        return eyeCount.GetComponent<TakenEye>().eyeCount;
    }
}
