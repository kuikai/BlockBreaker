using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Diagnostics;

public class PauseMenu : MonoBehaviour
{
   

    [Header("Audio")]
    [SerializeField] Slider Volume; 
    [SerializeField] AudioMixer mainAuido;
    [SerializeField] float defaulteVolume;
    [Header("Diferculty")]
    [SerializeField] Slider DifficultySlider;
    [SerializeField] float defaultediffeculty = 0;



    /// <summary>
    /// pop Up menu objects
    /// </summary>
    [Header("IngameMenu")]
    public GameObject pauseMenuUi;
    public GameObject PauseOptionMenuUI;
    public GameObject PauseMenuGameOverUI;
    public GameObject LevelCompleteLebel;
    // Update is called once per frame



    public static bool GameIsPause = false;
    public bool OptionIngameMenu = false;
    public static bool GameOver = false;
    public void Start()
    {
        if (DifficultySlider != null)
        {
           
        }

        if (Volume != null)
        {

        }
        //   PauseMenuGameOverUI.SetActive(false);
    }

    public void Mastervolume(float Volume)
    {

        if (mainAuido != null)
        {
           // mainAuido.SetFloat("Volume", PlayerPrefController.GetMasterVoulme());
        }
        else
        {

            UnityEngine.Debug.Log("Insert Auidiomixer int to pauseMenu script");
        }
    }

    public void SetDeferculty()
    {
     //   PlayerPrefController.SetDifficulty(DifficultySlider.value);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause && OptionIngameMenu )
            {
                Resume();
            }else
            {
                Pause();
            }
        }     
    }
    public void GobackToMainPauseMenu()
    {
    
    }
   

    public void SetwinlevelActive()
    {
        LevelCompleteLebel.SetActive(true);
    }
    public void SetwinlevelDicable()
    {
        LevelCompleteLebel.SetActive(false);
    }
    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    public void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    
    public void loadOptions()
    {
        pauseMenuUi.SetActive(false);
        PauseOptionMenuUI.SetActive(true);     
    }

    public void SetGameOverActive(){

        Time.timeScale = 0f;
        GameIsPause = true;
        PauseMenuGameOverUI.SetActive(true);
        
    }
   
    public void QuitQame()
    {
        Application.Quit();
    }
    public void Loardmenu()
    {

        Resetlevel();
        SceneManager.LoadScene("Start scenen");
    }
    public void loadSceneByName(string name)
    {
        
        SceneManager.LoadScene(name);
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Resetlevel()
    {
     //   GameHandler.Gm.gameOver = false;
   //     GameHandler.Gm.Reset();
        PauseMenuGameOverUI.SetActive(false);
        pauseMenuUi.SetActive(false);
        PauseOptionMenuUI.SetActive(false);
   //     FindObjectOfType<LevelController>().levelTimerFinish = false;
        LoardThisLevel();
    }
    public void LoardThisLevel()
    {
       // GameHandler.Gm.Reset();
        PauseMenuGameOverUI.SetActive(false);
        Time.timeScale = 1f;
      //  FindObjectOfType<GameHandler>().PlayerCurrentlife = (int)FindObjectOfType<GameHandler>().GerPlayerLife();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
