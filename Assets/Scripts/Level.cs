using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Level : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject blocks;    

    int currentlevel;
    void Start()
    {
        string ScenenName = SceneManager.GetActiveScene().name;
        string str = ScenenName.Substring(ScenenName.Length - 1);
        Debug.Log(str);
        currentlevel = int.Parse(str);
        blocks = GameObject.Find("Blocks");
        Debug.Log(blocks.transform.childCount);
    }
    // Update is called once per frame
    void Update()
    {
        loadNextLevel();
    }
    public void loadNextLevel()
    {
        if (blocks != null)
        {
            if (blocks.transform.childCount <= 0)
            {
                currentlevel += 1;

                if (SceneManager.GetActiveScene().name == "Level 9")
                {
                    SceneManager.LoadScene("WinGame");
                }
                else
                {
                    FindObjectOfType<GameSession>().NumberOfballs = 1;
                    SceneManager.LoadScene("Level " + currentlevel.ToString());
                }
            }
        }
    }

    public void You_won_lvl()
    {
        Debug.Log("You won");
    }
}
