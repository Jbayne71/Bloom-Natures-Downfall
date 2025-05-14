using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum BattleState
{
    Start, //Start of the battle
    PlayerTurn, //player action
    EnemyTurn, //enemy action
    FinishedTurn, //all turns finished
    Wait, //Waiting
    Lost // player dead
}

public class TurnHandle : MonoBehaviour
{
    public BattleState state;

    public EnemyProfile[] EnemiesInBattle;
    private bool enemyActed;
    private GameObject[] EnemyAtks;

    public GameObject PlayerUi;
    public HeartCtrl PlayerHeart;
    public Animator BossAnimations;
    public HealthBar healthBar;

    public int EnemyHP;
    
    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(EnemyHP);
        state = BattleState.Start;
        enemyActed = false;
        FindObjectOfType<AudioManager>().StopPlaying("MainMusic");
        FindObjectOfType<AudioManager>().StopPlaying("GameOverMusic");
        FindObjectOfType<AudioManager>().StopPlaying("Laugh");
        FindObjectOfType<AudioManager>().PlayMusic("BossMusic");
    }

    // Update is called once per frame
    void Update()
    {
        if (state == BattleState.Start)
        {
            PlayerUi.SetActive(false);
            StartCoroutine(PlayerActive());
        }
        else if (state == BattleState.PlayerTurn)
        {
            //wait for player to act
            PlayerHeart.gameObject.SetActive(false);
            PlayerUi.SetActive(true);
        }
        else if (state == BattleState.EnemyTurn)
        {

            if (EnemiesInBattle.Length <= 0)
            {
                EnemyFinishedTurn();
            }
            else
            {
                if (!enemyActed)
                {
                    //turn on player heart
                    PlayerHeart.gameObject.SetActive(true);
                    PlayerHeart.SetHeart();

                    BossAnimations.SetTrigger("Attack");

                    //create all battle effects in the enemy logics
                    foreach(EnemyProfile emy in EnemiesInBattle)
                    {
                        int AtkNumb = Random.Range(0, emy.EnemiesAttacks.Length);

                        Instantiate(emy.EnemiesAttacks[AtkNumb], Vector3.zero, Quaternion.identity);
                    }

                    //find all attacks in scene to check when they're done
                    EnemyAtks = GameObject.FindGameObjectsWithTag("Enemy");

                    enemyActed = true;
                }
                else
                {
                    bool enemyfin = true;
                    foreach (GameObject emy in EnemyAtks)
                    {
                        if (!emy.GetComponent<EnemyTurnHandle>().FinishedTurn)
                        {
                            enemyfin = false;
                        }
                    }

                    if (enemyfin)
                    {
                        EnemyFinishedTurn();
                    }
                }
            }
        }
        else if (state == BattleState.FinishedTurn)
        {
            BossAnimations.SetTrigger("Done");

            //turn is over turn off player heart
            PlayerHeart.gameObject.SetActive(false);

            //check if the player is alive at the end of turn
            if (PlayerHeart.GetComponent<PlayerHealth>().HP < 0)
            {
                state = BattleState.Lost;
            }
            else
            {
                state = BattleState.PlayerTurn;
            }
        }
        else if (state == BattleState.Lost)
        {
            //add game over screen
            PlayerUi.SetActive(false);
            Debug.Log("Lost");
        }
        else if (state == BattleState.Wait)
        {
            PlayerUi.SetActive(false);
        }
    }

    public void PlayerAct()
    {
        EnemyHP -= 1;
        healthBar.SetHealth(EnemyHP);
        state = BattleState.Wait;
        BossAnimations.SetTrigger("Hurt");
        FindObjectOfType<AudioManager>().PlayMusic("BossHurt");

        if (EnemyHP < 0)
        {
            Invoke("BattleWon", 2);
        }
        else
        {
            Invoke("playerfinishTurn", 2);
        }
    }

    public void playerfinishTurn()
    {
        //once the players turn has ended

        BossAnimations.SetTrigger("Done");
        PlayerUi.SetActive(false);
        state = BattleState.EnemyTurn;
    }

    void EnemyFinishedTurn()
    {
        //destroy all attacks
        foreach(GameObject obj in EnemyAtks)
        {
            Destroy(obj);
        }

        enemyActed = false;
        state = BattleState.FinishedTurn;
    }

    void BattleWon()
    {
        BossAnimations.SetTrigger("Dead");
        Invoke("AfterBattle", 3);
    }

    void AfterBattle()
    {
        FindObjectOfType<LevelLoader2>().LoadNextLevel2(); ;
    }

    public void Died()
    {
        PlayerHeart.gameObject.SetActive(false);
    }

    IEnumerator PlayerActive()
    {
        yield return new WaitForSeconds(2);

        state = BattleState.PlayerTurn;
    }
}
