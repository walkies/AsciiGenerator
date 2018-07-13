using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurnBasedStateMachine : MonoBehaviour
{
    public UnityEvent playerDamage;
    public UnityEvent EnemyDamage;
    public UnityEvent PlayerLoss;
    public UnityEvent EnemyLoss;

    public int playerHp;
    public int enemyHp;

    public enum States
    {
        PlayerTurn,
        EnemyTurn,
        Loss,
        Win
    }

    public States currentState;

	void Start ()
    {
        
	}
	

	void Update ()
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
            EnemyDamage.Invoke();
            currentState = States.EnemyTurn;
        }
        else if (currentState == States.EnemyTurn)
        {
            playerDamage.Invoke();
            currentState = States.PlayerTurn;
        }

        else if (playerHp <= 0)
        {
            currentState = States.Loss;
            PlayerLoss.Invoke();
            gameObject.SetActive(false);
        }

        else if (enemyHp <= 0)
        {
            currentState = States.Win;
            EnemyLoss.Invoke();
            gameObject.SetActive(false);
        }
    }
}
