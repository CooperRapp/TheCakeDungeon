using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField]
    public Transform player;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

    Rigidbody2D rb;

    public SpriteRenderer sr;
    public Sprite madEnemy;
    public Sprite normalEnemy;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < agroRange)
        {

            ChargePlayer();

        } else StopCharge();

    }

    void ChargePlayer()
    {

        sr.sprite = madEnemy;

        if (transform.position.x < player.position.x)
        {

            rb.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(-1, 1);

        }

        else if ((transform.position.x > player.position.x))
        {

            rb.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(1, 1);

        }
        else sr.sprite = normalEnemy;

    }

    void StopCharge()
    {

        rb.velocity = Vector2.zero;
        sr.sprite = normalEnemy;

    }

}
