using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy Profile")]
public class EnemyProfile : ScriptableObject
{
    public int Hp;

    public Sprite EnemyVisual;

    public GameObject[] EnemiesAttacks;
}
