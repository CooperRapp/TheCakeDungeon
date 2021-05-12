using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{

    Rigidbody2D rb;
    bool hasHit;
    bool knifeInGround;
    bool onFloor;

    public int damage = 50;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(!hasHit)
        {

            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        }

       if (onFloor) Destroy(gameObject, 1f);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        hasHit = true;
        if (collision.collider.tag == ("Ground") || collision.collider.tag == ("Player")) onFloor = true;
        if (collision.collider.tag == ("Enemy")) Destroy(gameObject);
        if (collision.collider.tag == ("KnifeInGround")) Destroy(gameObject);

    }

}
