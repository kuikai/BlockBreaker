using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_block : MonoBehaviour
{


    public void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<Paddle>().shooterOn = true;
        FindObjectOfType<Paddle>().DefaluteState = false;
    }


}
