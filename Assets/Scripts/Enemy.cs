using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event Action EnemyIsDead;

    public GameObject deathEffect;

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
            DeathEffect();
            EnemyIsDead?.Invoke();
            Destroy(gameObject);
          

        }
    }

    void DeathEffect()
    {

        GameObject tempEffect = Instantiate(deathEffect,transform.position,Quaternion.identity);
        tempEffect.transform.parent = null;

        Destroy(tempEffect,2);

    }

}
