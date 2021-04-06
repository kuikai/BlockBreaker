using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall_PowerUp : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<Paddle>().FireBallOn = true;
        FindObjectOfType<Paddle>().NextBall.Add("Fireball");
    }
}
