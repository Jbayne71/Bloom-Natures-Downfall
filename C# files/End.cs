using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<AudioManager>().StopPlaying("Rain");
    }

    public void StartMenu()
    {
        FindObjectOfType<LevelLoader>().LoadNextLevel();
    }
}
