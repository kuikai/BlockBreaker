using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBalls : MonoBehaviour
{

    [SerializeField] GameObject Ball;


    public bool PresstoSpaw = false;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("3Ball");
        //for (int i = 0; i < 3; i++)
        //{
        //    SpawnBall();
        //}
      
    }
    
    public void SpawnBall()
    {
        for (int i = 0; i < 3; i++)
        {
            Debug.Log("lalalal");
            Ball = Instantiate(Ball, transform.position, transform.rotation);
            Ball.GetComponent<Ball>().is_luch_ball = false;
            Ball.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(5, 10), Random.Range(5, 10));
            FindObjectOfType<GameSession>().NumberOfballs++;
        }
    }

    public void spaweBal()
    {
        Debug.Log("lalalal");
        Ball = Instantiate(Ball, transform.position, transform.rotation);
        Ball.GetComponent<Ball>().is_luch_ball = false;
        Ball.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(5, 10), Random.Range(5, 10));
        FindObjectOfType<GameSession>().NumberOfballs++;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(PresstoSpaw == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                spaweBal();

            }
        }
    }
    
}
