using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlayer : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<AudioManager>().StopPlaying("BossMusic");
        FindObjectOfType<AudioManager>().PlayMusic("DeadMusic");
    }
}
