using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        Debug.Log("PlayingMainMusic");
        FindObjectOfType<AudioManager>().StopPlaying("Laugh");
        FindObjectOfType<AudioManager>().StopPlaying("GameOverMusic");
        FindObjectOfType<AudioManager>().StopPlaying("DeadMusic");
        FindObjectOfType<AudioManager>().PlayMusic("MainMusic");
    }

    public void PlayGame ()
    {
        FindObjectOfType<LevelLoader>().LoadNextLevel();
    }

    public void QuitGame ()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
