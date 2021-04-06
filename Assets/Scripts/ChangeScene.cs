using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update

    

    private void Start()
    {
       

    }

    [System.Obsolete]
    public void Update()
    {
        
    }
    public void Change_Scene_string(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
        
        if(SceneManager.GetActiveScene().name == "Game Over")
        {
            FindObjectOfType<GameSession>().DestoySelf();
        }
    }


    public void QuitGame()
    {

        Application.Quit();
    }
    //public void PauseGame()
    //{
    //    if(InGameMenu != null)
    //    {
    //        Time.timeScale = 0;
    //        InGameMenu.SetActive(true);
    //    }
    //}
    //public void ResumeGame()
    //{
    //    if (InGameMenu != null)
    //    {
    //        Time.timeScale = 1;
    //        InGameMenu.SetActive(false);
    //    }
    //}
}
