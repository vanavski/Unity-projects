using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Description : MonoBehaviour {

    [Header("Description")]
    [TextArea]
    public string text;
    
    public string Activation()
    {
        return text;
    }
}
