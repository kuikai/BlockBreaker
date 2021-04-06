using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.IO;
using TMPro;
using System.Text;
using System.Linq;
using System;
public class Options : MonoBehaviour
{


    
    public TMP_Dropdown Quality_dropdown;
    public TMP_Dropdown TMP_Dropdown_Resolution;
    
    public AudioMixer Myaudio;
    public Slider AudioSlider;


    private int CurrentVolume = 0;
    private int qualityIndex;
    private bool Getindex;
    Resolution[] resolutions;
    List<Resolution> GameResolutions = new List<Resolution>();
    Resolution CurrentResolution;
    int currentResolutionindex = 0;

    public Text DebugText;

    // Start is called before the first frame update


    [System.Obsolete]
    void Start()
    {
        
  //      test.text = CurrentResolution.width.ToString() + " X" + CurrentResolution.height.ToString();
        Debug.Log("volume "+ GetGameVolume().ToString());
        Myaudio.SetFloat("MasterVolume", GetGameVolume());
        AudioSlider.value = GetGameVolume();
        if (TMP_Dropdown_Resolution != null)
        {
            SetUpResolutionDropDown();
        }

        ShowCurrentsettinges();
      // TMP_Dropdown_Resolution.value = 10;
    }

    [System.Obsolete]
    public void ShowCurrentsettinges()
    {
         CurrentResolution = Screen.currentResolution;
        if (Quality_dropdown != null)
        {
            Quality_dropdown.value = (int)QualitySettings.currentLevel - 1;
        }
    }
    public void SetUpResolutionDropDown()
    {
        resolutions = Screen.resolutions;
        TMP_Dropdown_Resolution.ClearOptions();
        Getindex = false;
        List<string> ResolutionOptions = new List<string>();
        currentResolutionindex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {      
            if (i >= 1)
            {
                if (resolutions[i - 1].height != resolutions[i].height && resolutions[i - 1].width != resolutions[i].width)
                {
                    if (Getindex == false)
                    {
                        currentResolutionindex += 1;
                    }
                    string option = resolutions[i].width + " X " + resolutions[i].height;
                    GameResolutions.Add(resolutions[i]);
                    ResolutionOptions.Add(option);
                }
            }        
            if(resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
              //  test.text = Screen.width.ToString() + " X" + Screen.height.ToString() + "index"
                Debug.Log(Screen.currentResolution.width.ToString());
                Getindex = true;
            }
        }

        TMP_Dropdown_Resolution.AddOptions(ResolutionOptions);
        TMP_Dropdown_Resolution.value = currentResolutionindex -1;
        TMP_Dropdown_Resolution.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        CurrentResolution = GameResolutions[resolutionIndex];
        DebugText.text = GameResolutions[resolutionIndex].width.ToString();
    }
   

    public void AudioVolume(float Volume)
    {
        CurrentVolume = (int)Volume;
        Myaudio.SetFloat("MasterVolume", (int)Volume);


        GameSession gameSession = FindObjectOfType<GameSession>();
           if(gameSession != null)
        {
            gameSession.CurrentGameVolume = Volume;
        }
        SetVolume();
    }

    public void SetGraphicsSettings(int QualityIndex)
    {
        
        qualityIndex = QualityIndex;
     
    }


    void SetVolume()
    {
        string path = Application.dataPath + "/Settings.txt";
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Settings \n\n");
        }
       
        string Content = "Master volume:" + CurrentVolume.ToString();
        File.WriteAllText(path, Content);
    
    }
    
    public static int GetGameVolume()
    {
        string path = Application.dataPath + "/Settings.txt";
        if (!File.Exists(path))
        {
            return 0;
        }
        else
        {
            List<string> lines = File.ReadAllLines(path).ToList();

            foreach (string line in lines)
            {
                if (line[0] == 'M')
                {
                    Char[] splitPoint = { ':' };
                    
                    string[] volume;
                    volume = line.Split(splitPoint);
                   // Debug.Log(volume[1]);
                   
               //     Debug.Log(volume[1][0]);
                    if (volume[1][0] == '-')
                    {
                       
                        string negativevolume = volume[1][1].ToString();
                        if(volume[1].Length ==3 )
                        {
                            negativevolume +=volume[1][2]; 
                        }
                        int Nvolume = Int16.Parse(negativevolume);
                       
                        Nvolume *=-1;
                        Debug.Log("minus" + Nvolume);
                        return Nvolume;
                    }
                    Debug.Log("HER HER" + volume[1]);
                    return Int16.Parse(volume[1].ToString());
                }
            }

        }
        return 0;
    }


    public void Apply()
    {
       
        Debug.Log(CurrentResolution.width + " X" + CurrentResolution.height );
        DebugText.text = CurrentResolution.height + "+ " + CurrentResolution.width;
        Screen.SetResolution(CurrentResolution.width, CurrentResolution.height, Screen.fullScreen);
        QualitySettings.SetQualityLevel(qualityIndex + 1);
    }
    
}
