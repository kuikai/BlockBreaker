using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using System;
using System.Linq;
using UnityEngine.UI;
public class HighScore : MonoBehaviour
{

    public TextMeshProUGUI HighScoreText;

    // Start is called before the first frame update
    void Start()
    {
        SetHighScore();
    }

    private void SetHighScore()
    {
        HighScoreText.text = " ";
       string path = Application.dataPath + "/HigheScore.txt";
        if (!File.Exists(path))
        {
            return;
        }
        else
        {
            List<string> lines = File.ReadAllLines(path).ToList();
            List<int> HighScores = new List<int>();
            foreach (string line in lines)
            {
                HighScores.Add(Int32.Parse(line));
            }
            HighScores.Sort();
            HighScores.Reverse();
            foreach ( int number in HighScores)
            {
                HighScoreText.text += number + "\n";
            }
        }
    } 

}
