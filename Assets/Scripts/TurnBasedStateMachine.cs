using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurnBasedStateMachine : MonoBehaviour
{
    public UnityEvent damageDeltToEnemies;
    public UnityEvent damageDeltToPlayer;
    public UnityEvent PlayerLoss;
    public UnityEvent EnemyLoss;

    public Player player;
    public Enemy enemy;

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
            damageDeltToEnemies.Invoke();
            currentState = States.EnemyTurn;
        }
        else if (currentState == States.EnemyTurn)
        {
            damageDeltToPlayer.Invoke();
            currentState = States.PlayerTurn;
        }

        else if (player.Health == 0)
        {
            currentState = States.Loss;
            PlayerLoss.Invoke();
            gameObject.SetActive(false);
        }

        else if (enemy.Health == 0)
        {
            currentState = States.Win;
            EnemyLoss.Invoke();
            gameObject.SetActive(false);
        }
    }
}
