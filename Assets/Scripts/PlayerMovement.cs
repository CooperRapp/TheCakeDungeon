using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header ("Player Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Animator topAnimator;
    public Animator bottomAnimator;
    public static bool moving;

    public Animator animator;

    public Rigidbody2D rb;

    [Header ("Ground Stuff")]
    public GameObject groundCheck;
    bool grounded;

    [Header("Flip Sprite")]
    public SpriteRenderer sp;
    public static bool facingRight = true;

    public GameObject child;
    void FixedUpdate()
    {

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        Flip(movement.x);
        WalkAnim(movement.x);

    }

    void Update()
    {

        Jump();

    }

    void WalkAnim(float x)
    {

        if (x > 0 || x < 0)
        {

            animator.SetBool("moving", true);
            topAnimator.SetBool("moving", true);
            bottomAnimator.SetBool("moving", true);
            moving = true;

        }
        else if (x == 0) 
        {

            animator.SetBool("moving", false);
            topAnimator.SetBool("moving", false);
            bottomAnimator.SetBool("moving", false);
            moving = false;

        } 

    }

    void Jump()
    {

        if (Input.GetButtonDown("Jump") && grounded)
        {

            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

        }

    }

    void Flip(float x)
    {

        if (x > 0 && !facingRight || x < 0 && facingRight)
        {

            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;

            Vector3 childScale = new Vector3(child.transform.localScale.x * -1, child.transform.localScale.y, child.transform.localScale.z);
            child.transform.localScale = childScale;

        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.collider.tag == "Ground")
        {

            grounded = true;

        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.collider.tag == "Ground")
        {

            grounded = false;

        }

    }

}
