using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public string NextScene;

    public Animator Crossfade;

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        Crossfade.SetTrigger("Transition");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(NextScene);
    }
}