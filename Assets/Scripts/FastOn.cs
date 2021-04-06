using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastOn : MonoBehaviour
{
    public void Adspeed() { 
        FindObjectOfType<GameSession>().SetSpeed(2,4);
        Debug.Log("gameSpeed On");
    }
}
