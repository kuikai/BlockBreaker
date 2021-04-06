using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowOn : MonoBehaviour
{
    public void SetSlowSpeed()
    {
        FindObjectOfType<GameSession>().SetSpeed(0.5f, 5);
    }
}
