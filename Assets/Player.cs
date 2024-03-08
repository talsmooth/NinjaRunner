using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }


    // Movement
    Rigidbody rb;
    public float playerMoveSpeed;
    public float playerAttackSpeed;
    [HideInInspector] public bool isAttacking;

    // Attack
    public float attackRangeTime;
    public float attackRangeTimeIncrease;
    float timer;
    float movement;

    // Life
    float playerLife;
    public float playerLifeIncrase;
    public float playerMaxLife;

    public static event Action PlayerIsAttacking;
    public static event Action PlayerIsDead;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        timer = attackRangeTime;
        playerLife = playerMaxLife;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movement

        Move();



        // Attack 

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isAttacking = true;
        }

        if (isAttacking)
        {

            timer -= Time.deltaTime;

            Attack();

            if (timer < 0)
            {

                isAttacking = false;
                timer = 0.5f;

            }

        }

    }

    public void Attack()
    {

        PlayerIsAttacking?.Invoke();

    }

    public void Move()
    {


        movement = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(movement * playerMoveSpeed, 0, 0);

    }


    public void Death() 
    {
       

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="Enemy")
        {
            PlayerIsDead += Death;
            PlayerIsDead?.Invoke();
            
        }
    }

    // Upgrades

    public void IncreaseAttackRange()
    {

        attackRangeTime += attackRangeTimeIncrease;

    }

    public void IncreaseLife()
    {

        playerMaxLife += playerLifeIncrase;

    }

    public void IncreaseDamage()
    {



    }

    public void HealthPacks()
    {



    }

  
}
