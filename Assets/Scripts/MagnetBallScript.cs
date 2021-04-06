using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetBallScript : MonoBehaviour
{
    Ball ball;
    Paddle paddle;
    Vector3 BallVelocity;
    Vector2 OffsetPositionToPaddle;
    private bool MangetBallOnPaddle;

    // Start is called before the first frame update
    void Start()
    {
        paddle = FindObjectOfType<Paddle>();
        ball = GetComponent<Ball>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
      //  Debug.Log("lalalallaMagnetball");
        if (collision.gameObject.tag == "MagnetPaddle")
        {
            MangetBallOnPaddle = true;
            Debug.Log("lalalallaMagnetball");
            BallVelocity = ball.myRigid2D.velocity;
            ball.myRigid2D.velocity = Vector3.zero;
            OffsetPositionToPaddle = transform.position - paddle.transform.position;
         //   transform.position = paddle.transform.position + OffsetPositionToPaddle  - new Vector3(0, 0.3f, 0);     
        }
    }
  

    // Update is called once per frame
   public void Update()
    {
        if (Input.GetMouseButtonDown(0) && MangetBallOnPaddle == true)
        {
            MangetBallOnPaddle = false;
            ball.myRigid2D.velocity = BallVelocity;

        }
        MagnetToPaddle();

    }

    public void FixedUpdate()
    {
      
       
    }
    public void MagnetToPaddle()
    {
        if (MangetBallOnPaddle == true)
        {
            Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
            transform.position = paddlePos + OffsetPositionToPaddle - new Vector2(0, 0.3f); 
           // transform.position = paddle.transform.position + OffsetPositionToPaddle - new Vector3(0, 0.3f, 0);
        }
    }

}


