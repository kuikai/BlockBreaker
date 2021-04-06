using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System.Linq;
public class GetScore : MonoBehaviour
{
    GameSession gameSession;
   public  TextMeshProUGUI TMP_Text;
    void Start()
    {


        TMP_Text = GetComponent<TextMeshProUGUI>();
        AddScore(FindObjectOfType<GameSession>().GetScore().ToString());
        TMP_Text.text = FindObjectOfType<GameSession>().GetScore().ToString();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SethighScore(string Line)
    {

    }

    public static void AddScore(string Score)
    {
        string path = Application.dataPath + "/HigheScore.txt";

        if (!File.Exists(path))
        {
            File.WriteAllText(path, " ");
        }

        List<string> Lines = File.ReadAllLines(path).ToList();


        Lines.Add(Score);

        File.WriteAllLines(path,Lines);


    }


}
