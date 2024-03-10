using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;




public class Enemy : MonoBehaviour
{
    public static event Action EnemyIsDead;

    public GameObject deathEffect;

    public float moveSpeed = 2.0f;
    bool isLeft;

    public int chanceToPatrol;
    bool isPatrol;


    void Start()
    {

        int rand = UnityEngine.Random.Range(0, 101);
        if (rand <= chanceToPatrol )
        {
            isPatrol = true;
        }

    }

   
    void Update()
    {

        if (isPatrol)
        {
            Patrol();
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

    public void Patrol()

    {

        if (!isLeft)
        {

            transform.Translate(Vector3.left * Time.deltaTime * 5);
        }


        if (transform.position.x < -4)
        {

            isLeft = true;

        }

        if (isLeft)
        {
            transform.Translate(Vector3.right * Time.deltaTime * 5);


        }

        if (transform.position.x > 4)
        {
            isLeft = false;

        }

    }
 

    }
