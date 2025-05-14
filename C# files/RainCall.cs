using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCall : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<AudioManager>().PlayMusic("Rain");
    }
}
