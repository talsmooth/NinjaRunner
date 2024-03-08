using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event Action EnemyIsDead;

    void Start()
    {
        
    }

   
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            EnemyIsDead?.Invoke();
            Destroy(gameObject);
          

        }
    }


}
