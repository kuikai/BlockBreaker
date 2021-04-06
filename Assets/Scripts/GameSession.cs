using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
public class GameSession : MonoBehaviour
{
    [Range(0.1f,10f)]  [SerializeField] float gameSpeed;
    
    [SerializeField] int Points_per_block_Destoyed = 83;
    [SerializeField] int currtentScorre = 0;
    [SerializeField] TextMeshProUGUI  scoreText;
    [SerializeField] bool AutoPlay;


    public GameObject InGameMenu;

    public Vector2 PaddleStart_pos; 

    public bool GameRunning = true;
    
    public int NumberOfballs;
    public int Lives  = 3;

    public bool faston;
    public float FastOnTime;

    public  float CurrentGameVolume;
    private float TimeOnGoing;

    public static bool pauseGame = false;
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;

        if(gameStatusCount > 1)
        {
            Destroy(gameObject);

        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

    internal void GameOver()
    {
        Lives = 3;
 
    }

    public bool ReturnAutoplay()
    {
        return AutoPlay;
    }
    void Start()
    {
        CurrentGameVolume = Options.GetGameVolume();
        NumberOfballs = GameObject.FindGameObjectsWithTag("Ball").Length;     
        scoreText.text = currtentScorre.ToString();
    }
    public int GetScore()
    {
        return currtentScorre;
    }

    // Update is called once per frame
    void Update()
    {
        FastOnMethod();
        Time.timeScale = gameSpeed;

        if (InGameMenu != null)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                 
                if (pauseGame)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                  
                }
            }
        }
    }
    public void FastOnMethod()
    { 
        if ( faston == true)
        {
          //  Debug.Log("Time" + TimeOnGoing);
            TimeOnGoing += Time.deltaTime;
            if (TimeOnGoing > FastOnTime)
            {
                gameSpeed = 1;
                faston = false;
                FastOnTime = 0;
            }
        }      
    }
    public void Reset()
    {
        NumberOfballs = GameObject.FindGameObjectsWithTag("Ball").Length;
        FindObjectOfType<Paddle>().Reset();
    }

    public void AddToScore()
    {
        currtentScorre = currtentScorre += Points_per_block_Destoyed;
        scoreText.text = currtentScorre.ToString();
     //   Debug.Log("addAcore" + currtentScorre);
    }

    public void AddToScore(int points)
    {
        currtentScorre = currtentScorre += points;
        scoreText.text = currtentScorre.ToString();
        //Debug.Log("addAcore" + currtentScorre);
    }
    public void DestoySelf()
    {
        Debug.Log("Gameseision over");
        Destroy(gameObject);
    }
    public void SetSpeed(float speed, float TimeForSpeed)
    {
        FastOnTime = TimeForSpeed;
        gameSpeed = speed;
        faston = true;
    }

    public void Change_Scene(string SceneName)
    {
        if (SceneName == "Starte Menu")
        {
            FindObjectOfType<GameSession>().DestoySelf();
        }
        SceneManager.LoadScene(SceneName);
    }
    public void Change_Scene_string(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void PauseGame()
    {
        Paddle.PaddleAktive = false;
        gameSpeed = 0;
        InGameMenu.SetActive(true);
        pauseGame = true;
    }

    public void ResumeGame()
    {
        Paddle.PaddleAktive = true;
        gameSpeed = 1;
        InGameMenu.SetActive(false);
       pauseGame = false;
    }


    public void QuitGame()
    {
        Application.Quit();
    }
   
}

