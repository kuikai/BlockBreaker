using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] Sprite[] Defualt_animation;
    [SerializeField] Sprite[] Shotter_animation;

    [Header("GameObject")]
    [SerializeField] GameObject FirBall;
    [SerializeField] GameObject mangetBall;
    [SerializeField] GameObject Ball;
    [SerializeField] GameObject Projectile;
    [Header("Sprits")]
    [SerializeField] Sprite[] Long;
    [SerializeField] Sprite small;

    [SerializeField] Ball ball;
    [SerializeField] Vector3 BallOffsetToPaddle;
    // Start is called before the first frame update
    [SerializeField] float screenWidthUnits = 16f;
    [SerializeField] float min = 2, max = 14;    
    // cached reference
    GameSession theGameSesseon;
    Ball theBall;
    private int number;
    float t = 0;
    private float LongOnTimer;
   
    /// <summary>
    /// public stuff
    /// </summary>
    [Header("longOn")]
    public float longOntime;
    public bool LongOn= false;
    public bool smallOn = false;

    [Header("FireBall")]
    public bool FireBallOn = false;

    [Header("MangnetBall")]
    public bool MangnetBallOn = false;
    

    [Header("Shooter")]
    private float TimerShooter = 0;
    public float ShooterTime = 4;
    public bool shooterOn = false;

    [Header("Default")]
    public bool DefaluteState = true;

    public List<string> NextBall = new List<string>();

    public static bool PaddleAktive = true;
    void Start()
    {      
        theGameSesseon = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PaddleAktive == true)
        {
            t += Time.deltaTime;
            DefualtAnimetion();
            ShouterMode();
            Small();
            Longer();
            PlayerMove();
        }
    }

    private void Longer()
    {
        if (LongOn == true)
        {
            LongOnTimer += Time.deltaTime;
            if (LongOnTimer > longOntime)
            {
                LongOn = false;
                DefaluteState = true;                  
            }
        }
        if (t > 0.2f && LongOn == true)
        {
            number++;
            Debug.Log(number);
            if (number >= Defualt_animation.Length)
            {
                number = 0;
            }
            GetComponent<SpriteRenderer>().sprite = Long[number];
            t = 0;
        }
    }

    private void Small()
    {
        if (smallOn == true)
        {
            GetComponent<SpriteRenderer>().sprite = small;
        }
    }

    private void ShouterMode()
    {
        if (t > 0.2f && shooterOn == true)
        {
            TimerShooter += Time.deltaTime;
          //  Debug.Log(TimerShooter);
            Shoot();
            t = 0;
            if (TimerShooter > ShooterTime)
            {
                TimerShooter = 0;
                shooterOn = false;
            }
        }
    }
    private void ShooterAnimation()
    {
        number++;
        Debug.Log(number);
        if (number >= Defualt_animation.Length)
        {
            number = 0;
        }
        GetComponent<SpriteRenderer>().sprite = Shotter_animation[number];
    }
    private void DefualtAnimetion()
    {
        if (t > 0.2f && DefaluteState == true)
        {
            number++;
    //     Debug.Log(number);
            if (number >= Defualt_animation.Length)
            {
                number = 0;
            }
            GetComponent<SpriteRenderer>().sprite = Defualt_animation[number];
            t = 0;
        }
    }
    private void PlayerMove()
    {
        float MousePosx = Input.mousePosition.x / Screen.width * screenWidthUnits;
        Vector2 PaddelePos = new Vector2(transform.position.x, transform.position.y);
        PaddelePos.x = Mathf.Clamp(GetXPos(), min, max);
        transform.position = PaddelePos;
    }
   
    private float GetXPos()
    {
        if (theGameSesseon.ReturnAutoplay())
        {      
           if(theBall == null)
           {
                Reset();
           }
            if (theBall != null)
            {
                return theBall.transform.position.x;
            }
            return 1;
        }
        else
        {
          return Input.mousePosition.x / Screen.width * screenWidthUnits;
        }
    }

   public void Reset()
   {
        if(NextBall.Count != 0)
        {
            switch (NextBall[0])
            {
                case "Fireball":
                    InstantiateFireBall();
                    NextBall.RemoveAt(0);
                    FireBallOn = false;
                    break;
                case "MagnetBall":
                    IntantiateMagnetBall();
                    NextBall.RemoveAt(0);
                    MangnetBallOn = false;
                    break;
                default:
                    break;
            }
        }else
        {
            theBall = Instantiate(ball, transform.position + BallOffsetToPaddle, transform.rotation);       
        }
        //if (FireBallOn == true && mangetBall != true)
        //{
        //    InstantiateFireBall();
        //    FireBallOn = false;
        //}
        //if(MangnetBall == true && FireBallOn != true)
        //{
        //    IntantiateMagnetBall();
        //    MangnetBall = false;
        //}
   }

    public void InstantiateBall()
    {
        Instantiate(ball, transform.position + BallOffsetToPaddle, transform.rotation);
    }
    public void InstantiateFireBall()
    {
        Instantiate(FirBall, transform.position + BallOffsetToPaddle, transform.rotation);
    }

    public void IntantiateMagnetBall()
    {
        Instantiate(mangetBall, transform.position + BallOffsetToPaddle, transform.rotation);
    }
    public void Shoot()
    {
        float speed = 10;
        GameObject NewProjectil1 = Instantiate(Projectile, new Vector3(0.85f, 0.4f, 0) + transform.position, Quaternion.identity);

        NewProjectil1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
         
        GameObject NewProjectil2 = Instantiate(Projectile, new Vector3(-0.85f,0.4f,0) + transform.position, Quaternion.identity);

        NewProjectil2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
    }
}
