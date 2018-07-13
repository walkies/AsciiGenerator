using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ScriptableStats stats;

    void Start()
    {

    }

    void Update()
    {
        if (stats.Health <= 0)
        {
            //gameObject.SetActive(false);
        }
    }
}
