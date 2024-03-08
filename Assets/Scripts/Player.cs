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
    public float playerLife;
    public float playerMaxLife;
    public float playerLifeIncrase;

    // LevelUp
    public int scoreToLevelUp;


    // Events
    public static event Action PlayerIsAttacking;
    public static event Action PlayerIsHit;
    public static event Action PlayerIsDead;
    public static event Action PlayerIsAddedScore;
    public static event Action PlayerIsLeveledUp;

    // Score

    public int playerScore;


    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        timer = attackRangeTime;
        playerLife = playerMaxLife;
        rb = GetComponent<Rigidbody>();

        playerScore = 0;
        PlayerIsAddedScore += AddScore;

        PlayerIsHit += Hit;
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
                timer = attackRangeTime;

            }

        }


        if (playerScore == scoreToLevelUp )
        {

            PlayerIsLeveledUp?.Invoke();

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

    public void Hit()
    {
        playerLife -= 10;
    }

    public void AddScore()
    {


        playerScore++;


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && !isAttacking)
        {

            PlayerIsHit?.Invoke();

            if (playerLife < 10)
            {

                PlayerIsDead?.Invoke();

            }

        }

        else

            if (other.gameObject.tag == "Enemy" && isAttacking)
        {
            
            PlayerIsAddedScore.Invoke();

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
