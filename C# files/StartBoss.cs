using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBoss : MonoBehaviour
{
    public void LoadBoss()
    {
        FindObjectOfType<LevelLoader>().LoadNextLevel();
    }
}
