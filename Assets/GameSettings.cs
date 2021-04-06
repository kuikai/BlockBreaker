using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class GameSettings : MonoBehaviour
{
    // Start is called before the first frame update


    
    void Start()
    {
        CreateText();

        CreateHigeScoreText();
    }

    void CreateText()
    {
        string path = Application.dataPath + "/Settings.txt";
        if (!File.Exists(path))
        {
            File.WriteAllText(path,"Master volume:0");
        }
    }
   public void CreateHigeScoreText()
    {
        string path = Application.dataPath + "/HigheScore.txt";
       
        if (!File.Exists(path))
        {
            File.WriteAllText(path, " ");
        }
    }
}
