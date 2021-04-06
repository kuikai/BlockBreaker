using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall_Destoyer : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Breakable")
        {
         
            collision.GetComponent<Block>().BreakBlock();
            
        }
    }
}
