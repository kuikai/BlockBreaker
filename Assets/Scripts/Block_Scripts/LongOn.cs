using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongOn : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<Paddle>().DefaluteState = false;
        FindObjectOfType<Paddle>().LongOn = true;
    }
}
