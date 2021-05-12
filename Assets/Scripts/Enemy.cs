using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 50;
    public GameObject deathEffect;

    public void TakeDamage(int damage)
    {

        health -= damage;

        if(health <= 0)
        {

            Die();

        }

    }
    void Die()
    {

        Instantiate(deathEffect, transform.position, transform.rotation);

        Destroy(gameObject);

    }

     void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == ("CakeKnife")) TakeDamage(50);
        
    }

    

}
