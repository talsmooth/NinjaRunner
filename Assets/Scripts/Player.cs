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
    public float playerLifeIncrease;

    // Frenzy
    public int playerKillsToFrenzy;
    public int playerKills;
    public float FrenzyTime;
    private float frenzyTimer;
    public bool isFrenzy;





    // Events
    public static event Action PlayerIsAttacking;
    public static event Action PlayerIsDead;
    public static event Action PlayerIsAddedScore;
    public static event Action PlayerIsLeveledUp;
    public static event Action PlayerIsInFrenzy;

    // Effects
    public ParticleSystem frenzyEffect;





    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        timer = attackRangeTime;
        playerLife = playerMaxLife;
        rb = GetComponent<Rigidbody>();

        

        PlayerIsAddedScore += AddKills;
        PlayerIsAttacking += Attack;
        PlayerIsInFrenzy += Frenzy;

        frenzyTimer = FrenzyTime;

    }

    void Update()
    {
        // Movement

        Move();

        // Attack 

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerIsAttacking?.Invoke();
           
        }

        if (isAttacking && !isFrenzy)
        {

            timer -= Time.deltaTime;


            if (timer < 0)
            {

                isAttacking = false;
                timer = attackRangeTime;

            }

        }

        // Life

        if (playerLife == 0)
        {

            PlayerIsDead?.Invoke();

        }

        // Frenzy

        if (playerKills == playerKillsToFrenzy)
        {
            isFrenzy = true;
            isAttacking = false;

            frenzyTimer -= Time.deltaTime; 

           // GameObject tempEffect = Instantiate(frenzyEffect,transform.position,Quaternion.identity);
            frenzyEffect.Play();

            

            if(frenzyTimer <= 0)
            {
                playerKills = 0;
                isFrenzy = false;
                frenzyTimer = FrenzyTime;

                

            }

        }

        else frenzyEffect.Stop();      
        

    }

    public void Attack()
    {

        isAttacking = true;


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

    public void AddKills()
    {


        playerKills++;


    }

    public void Frenzy()
    {

        playerKills = 0;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && !isAttacking && !isFrenzy)
        {

            Hit();


        }

        else

            if (other.gameObject.tag == "Enemy" && isAttacking)
        {
            
            PlayerIsAddedScore.Invoke();

        }

        if (other.gameObject.tag == "LaserWall")
        {

            playerLife = 0;


        }


        if (other.gameObject.tag == "UpgradeBox")
        {

            PlayerIsLeveledUp?.Invoke();


        }



    }

    // Upgrades

    public void IncreaseAttackRange()
    {

        attackRangeTime += attackRangeTimeIncrease;

    }

    public void IncreaseMaxLife()
    {

        playerMaxLife += playerLifeIncrease;
        playerLife = playerMaxLife;

    }

    public void IncreaseDamage()
    {



    }

    public void ExtraFrenzyTime()
    {

       FrenzyTime += 1;

    }

  
}
