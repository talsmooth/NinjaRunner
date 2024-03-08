using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event Action EnemyIsDead;

    public GameObject deathEffect;

    bool moveLeft;
    bool moveRight;
    public float speed = 4f;

    void Start()
    {
      
    }

   
    void Update()
    {

        if (transform.position.x > 0)
        {
            moveLeft = true;

        }
        if (moveLeft && transform.position.x > -4)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);

        }

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
