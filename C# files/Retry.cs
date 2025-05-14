using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<AudioManager>().StopPlaying("BossMusic");
        FindObjectOfType<AudioManager>().PlayMusic("GameOverMusic");
        FindObjectOfType<AudioManager>().PlayMusic("Laugh");
    }

    public void RestartLevel()
    {
        FindObjectOfType<LevelLoader>().LoadNextLevel();
    }

    public void ReturnToMenu()
    {
        FindObjectOfType<LevelLoader2>().LoadNextLevel2();
    }
}
