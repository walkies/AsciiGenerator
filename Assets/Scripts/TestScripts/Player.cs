using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ScriptableStats stats;
    public TurnBasedStateMachine battlesystem;

    void Start ()
    {
		
	}
	
	void Update ()
    {
        if (stats.Health <= 0)
        {
            gameObject.SetActive(false);
        }
	}
    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("enemy"))
        {
            battlesystem.gameObject.SetActive(true);
            battlesystem.SetEnemy(col.gameObject);
        }
    }
}
