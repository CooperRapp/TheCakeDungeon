using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAim : MonoBehaviour
{

    public GameObject knife;
    public float launchForce;
    public Transform firePoint;
    public Animator animator;
    public Animator topAnimator;
    public Animator bottomAnimator;

    bool finishedThrow;
    void Update() //want to use for physics-based stuff
    {

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize(); //between 0-1

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        if (Input.GetMouseButtonDown(0) && AnimationDone.doneAnim)
        {

            AnimationDone.doneAnim = false;
            StartCoroutine(Throw());
           

        }

    }
    void Shoot()
    {

        GameObject newKnife = Instantiate(knife, firePoint.position, firePoint.rotation);
        newKnife.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;

    }

    IEnumerator Throw()
    {
        if(!PlayerMovement.moving) bottomAnimator.SetBool("throwing", true);
        topAnimator.SetBool("moving", false);
        topAnimator.SetBool("throwing", true);
        animator.SetBool("throwing", true);

        yield return new WaitForSeconds(0.26f);

        topAnimator.SetBool("throwing", false);
        bottomAnimator.SetBool("throwing", false);
        
        animator.SetBool("throwing", false);

        if(PlayerMovement.moving) topAnimator.SetBool("moving", true);

        Shoot();

    }

}
