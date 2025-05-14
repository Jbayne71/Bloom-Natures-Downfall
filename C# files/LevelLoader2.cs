using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader2 : MonoBehaviour
{
    public string NextScene2;

    public Animator Crossfade;

    public void LoadNextLevel2()
    {
        StartCoroutine(LoadLevel2());
    }

    IEnumerator LoadLevel2()
    {
        Crossfade.SetTrigger("Transition");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(NextScene2);
    }
}