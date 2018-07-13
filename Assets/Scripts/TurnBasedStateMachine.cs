using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurnBasedStateMachine : MonoBehaviour
{
    public States currentState;
    public ScriptableStats player;
    public Enemy enemy;
    public GameObject UI;

    public enum States
    {
        PlayerTurn,
        EnemyTurn,
        Loss,
        Win
    }

    public UnityEvent somethingToEnemies;
    public UnityEvent somethingToPlayer;
    public UnityEvent PlayerLoss;
    public UnityEvent EnemyLoss;

    void Start()
    {
        UI.SetActive(true);
    }


    void Update()
    {
        Debug.Log(currentState);
        switch (currentState)
        {
            case (States.PlayerTurn):
                break;
            case (States.EnemyTurn):
                break;
            case (States.Loss):
                break;
            case (States.Win):
                break;
        }
    }
    public void NewState()
    {
        if (currentState == States.PlayerTurn)
        {
            if (player.Health <= 0)
            {
                currentState = States.Loss;
                PlayerLoss.Invoke();
                gameObject.SetActive(false);
            }
            else
            {
                enemy.stats.Health = enemy.stats.Health - player.Damage;
                somethingToEnemies.Invoke();
                currentState = States.EnemyTurn;
                return;
            }
        }

        if (currentState == States.EnemyTurn)
        {
            if (enemy.stats.Health <= 0)
            {
                currentState = States.Win;
                EnemyLoss.Invoke();
                gameObject.SetActive(false);
            }
            else
            {
                player.Health = player.Health - enemy.stats.Damage;
                somethingToPlayer.Invoke();
                currentState = States.PlayerTurn;
                return;
            }
        }
    }
    public void SetEnemy(GameObject givenEnemy)
    {
        enemy = givenEnemy.GetComponent<Enemy>();
    }
}
