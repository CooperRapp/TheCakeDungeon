using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcquiredNotifation : MonoBehaviour
{

    void Achivement()
    {


        Destroy(gameObject);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Player") Achivement();

    }

}
