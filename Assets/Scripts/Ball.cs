
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] Paddle paddle1;
    [SerializeField] int lunch_powerx = 3, lunch_powery = 15;
    private bool Luch_ball = false;
    [SerializeField] float randomFactor;
    [SerializeField] AudioClip[] ballsounds;
    [SerializeField] GameObject FireOnBall;
    [SerializeField] bool FireBall;
    public bool is_luch_ball = true;
    // state 
    Vector2 paddleTovallvector;

    //Cashed componet refrence

    public  AudioSource myAudioSource;
    public Rigidbody2D myRigid2D;
    // Start is called before the first frame update
    void Start()
    {
        if (is_luch_ball)
        {
            paddle1 = FindObjectOfType<Paddle>();
            paddleTovallvector = transform.position - paddle1.transform.position;
            myAudioSource = GetComponent<AudioSource>();
            myRigid2D = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!Luch_ball && is_luch_ball)
        {
            Lock_Ball_to_Paddle();
            Launch_On_Mouse_click();
        }
     //   Debug.Log("Ball Velochit" + myRigid2D.velocity);
    }
    public Vector3 GetBallVelocity()
    {
        return myRigid2D.velocity;
    }
    private void Launch_On_Mouse_click()
    {
      if (Input.GetMouseButtonDown(0))
      {
            if (Paddle.PaddleAktive == true)
            {
                Luch_ball = true;
                GetComponent<Rigidbody2D>().velocity = new Vector2(lunch_powerx, lunch_powery);
            }
      }
    }

    private void Lock_Ball_to_Paddle()
    {           
       Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
       transform.position = paddlePos + paddleTovallvector;       
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (myAudioSource == null)
        {
            myAudioSource = GetComponent<AudioSource>();
         

            Debug.Log("hihisdadshih");
        }
        AudioClip clip = ballsounds[UnityEngine.Random.Range(0, ballsounds.Length)];
        myAudioSource.PlayOneShot(clip);
        //    Debug.Log("hihihih");
        if (FireBall!= true)
        {
    //        Debug.Log("hihihih");
            Vector2 VelociTweak = new Vector2
                (Random.Range(0f, randomFactor),
                 Random.Range(0, randomFactor));

            if (Luch_ball == true)
            {            
                AudioClip clips = ballsounds[UnityEngine.Random.Range(0, ballsounds.Length)];
                //Debug.Log("hihisdadshih");
                myAudioSource.PlayOneShot(clips);
                myRigid2D.velocity += VelociTweak;
            }
        }
    }
    
}
