using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public GameObject deathEffect;

    public int health = 3;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Update()
    {

        monitorHealth();

    }

    void TakeDamage(int damage)
    {

        health -= damage;
        if(health == 0) Die();

    }

    void monitorHealth()
    {

        if (health > numOfHearts) health = numOfHearts;

        for (int i = 0; i < hearts.Length; i++)
        {

            if (i < health) hearts[i].sprite = fullHeart;
            else hearts[i].sprite = emptyHeart;

            if (i < numOfHearts) hearts[i].enabled = true;
            else hearts[i].enabled = false;

        }

    }

    void Die()
    {

        health = 0;
        monitorHealth();
        Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(gameObject);
       // gameObject.GetComponent<PlayerMovement>().enabled = false;
       // Camera.main.GetComponent<CameraFollow>().enabled = false;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == ("Spike")) Die();
        if (collision.collider.tag == ("Enemy")) TakeDamage(1);

    }

}
