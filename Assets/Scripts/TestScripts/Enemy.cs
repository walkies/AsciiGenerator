using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health = 10;

    void Start()
    {

    }

    void Update()
    {
        if (Health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    public void TakeDamage(int damageTaken)
    {
        Health = Health - damageTaken;
    }
}
