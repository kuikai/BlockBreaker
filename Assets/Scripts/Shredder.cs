using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            Destroy(collision.gameObject);
        }
    }
}
