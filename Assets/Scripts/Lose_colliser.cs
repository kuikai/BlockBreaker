using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Lose_colliser : MonoBehaviour
{
    public string loadscene;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {     
        if (collision.gameObject.tag == "Ball")
        {
            Destroy(collision.gameObject);
            FindObjectOfType<GameSession>().NumberOfballs -= 1;
        }
        if (FindObjectOfType<GameSession>().NumberOfballs == 0 )
        {
            Removelife();
            FindObjectOfType<GameSession>().Lives -= 1;
            FindObjectOfType<GameSession>().Reset();
            if (FindObjectOfType<GameSession>().Lives <= 0)
            {
                Change_Scene(loadscene);
                FindObjectOfType<GameSession>().GameOver();
            }
        }
    }
    private static void Removelife()
    {
        if (FindObjectOfType<GameSession>().Lives == 3)
        {
            GameObject.Find("Life 1").active = false;
        }
        if (FindObjectOfType<GameSession>().Lives == 2)
        {
            GameObject.Find("Life 2").active = false;
        }
        if (FindObjectOfType<GameSession>().Lives == 1)
        {
            GameObject.Find("Life 3").active = false;
        }
    }
    private void Change_Scene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
