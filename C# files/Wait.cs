using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Nextlvl());
    }

    IEnumerator Nextlvl()
    {
        yield return new WaitForSeconds(6);

        FindObjectOfType<LevelLoader>().LoadNextLevel();
    }
}
