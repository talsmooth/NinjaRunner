using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float playerMoveSpeed;
    public float attackSpeed;
    private bool isAttacking;

    float timer;
    float movement;

    void Start()
    {
        timer = 0.5f;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movement

        movement = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(movement * playerMoveSpeed, 0, 10);
        



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

        rb.AddForce(0, 0, attackSpeed, ForceMode.Impulse);

    }

}
