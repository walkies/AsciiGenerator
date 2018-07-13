using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Health = 10;
    public GameObject battlesystem;
    public GameObject UI;

    void Start ()
    {
		
	}
	
	void Update ()
    {
        if (Health <= 0)
        {
            gameObject.SetActive(false);
        }
	}
    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("enemy"))
        {
            UI.SetActive(true);
            battlesystem.SetActive(true);
        }
    }
    public void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("enemy"))
        {
            UI.SetActive(false);
            battlesystem.SetActive(false);
        }
    }
    public void TakeDamage(int damageTaken)
    {
        Health = Health - damageTaken;
    }

}
