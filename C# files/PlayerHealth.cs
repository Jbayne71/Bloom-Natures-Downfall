using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int HP;
    public int MaxHp;

    public HealthBar healthBar;

    public Animator animator;

    public void TakeDamage(int Dmg)
    {
        HP -= Dmg;

        healthBar.SetHealth(HP);

        if (HP <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        FindObjectOfType<TurnHandle>().Died();

        Debug.Log("PlayerHasDied");
        FindObjectOfType<LevelLoader>().LoadNextLevel();
    }

    // Start is called before the first frame update
    void Start()
    {
        HP = MaxHp;
        healthBar.SetMaxHealth(MaxHp);
    }

    public void HitScan()
    {
        animator.SetTrigger("Attack");
        FindObjectOfType<AudioManager>().PlayMusic("PlayerHurt");
    }
}
