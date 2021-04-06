using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetBall_Block : MonoBehaviour
{
      public void SetMagnetBalltrue()
    {
        FindObjectOfType<Paddle>().MangnetBallOn = true;
        FindObjectOfType<Paddle>().NextBall.Add("MagnetBall");
    }
}
