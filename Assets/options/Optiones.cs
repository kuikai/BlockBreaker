using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Xml.Serialization;
using System;

public class Optiones : MonoBehaviour
{
    /// <summary>
    /// Audio Varibels
    /// </summary>
    public AudioMixer audioMixer;

    [SerializeField] AudioMixerGroup[] audioMixerGroup;
     private AudioSource audio;
 
    [SerializeField] string MainMixerParamaName;
    [SerializeField] string AudioParameterName1;
    [SerializeField] string AudioParameterName2;
    [SerializeField] string AudioParameterName3;

    public AudioClip VoulumeIndecater;

   
   // public Slider MasterAudioSlider;
   /// <summary>
   /// Resolution Varibels
   /// </summary>
    [SerializeField] TMP_Dropdown ResolutionDropdown;
    Resolution[] ScreenResolutions;
    List<Resolution> GameResolutions = new List<Resolution>();
    private Resolution GameResolution;

    /// <summary>
    /// keybindings
    /// </summary>
    public Transform Keybindings;
    private TextMeshProUGUI ButtonText;
    private Event keyEvent;

    private bool waitingForKey;
    private  KeyCode newkey;

    /// <summary>
    /// GraphicKvality
    /// </summary>
    private int GraphicsQvality;

    private void Start()
    {      
        audio = GetComponent<AudioSource>();
        audio.outputAudioMixerGroup = audioMixerGroup[0];
        waitingForKey = false;
      //  Screen.SetResolution(1920   ,1080, Screen.fullScreen);        
        // SetKeybindsNames();
        Resolution();
    }



    private void Update()
    {

        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    Application.Quit();
        //}


    }

    ///////////////////////////////////////////////////////////////// Keybinds////////////////////////////////
    /// <summary>
    /// Sets text til current keybindings
    /// </summary>
    //private void SetKeybindsNames()
    //{
    //    for (int i = 0; i < 5; i++)
    //    {
    //        if (Keybindings.GetChild(i).name == "ForwardButton")
    //        {
    //            Keybindings.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = GameManager.Gm.Forward.ToString();
    //        }
    //        if (Keybindings.GetChild(i).name == "BackwardButton")
    //        {
    //            Keybindings.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = GameManager.Gm.BackWard.ToString();
    //        }
    //        if (Keybindings.GetChild(i).name == "Right Button")
    //        {
    //            Keybindings.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = GameManager.Gm.Right.ToString();
    //        }
    //        if (Keybindings.GetChild(i).name == "Left Button")
    //        {
    //            Keybindings.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = GameManager.Gm.Left.ToString();
    //        }
    //        if (Keybindings.GetChild(i).name == "InteractButton")
    //        {
    //            Keybindings.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = GameManager.Gm.Interact.ToString();
    //        }

    //    }
    //}


    //void OnGUI()
    //{
    //    //   Debug.Log("presse key change");
    //    keyEvent = Event.current;
    //    if (keyEvent.isKey && waitingForKey)
    //    {
    //        Debug.Log("presse key change");
    //        newkey = keyEvent.keyCode;
    //        waitingForKey = false;
    //    }
    //}


    //public void StartAssingments(string KeyName)
    //{
    //    if (!waitingForKey)
    //    {
    //        StartCoroutine(AssingnKey(KeyName));
    //    }
    //}

    //public void SentText(TextMeshProUGUI text)
    //{
    //    ButtonText = text;

    //}


    //IEnumerator waitForkey()
    //{
    //    while (!keyEvent.isKey)
    //    {
    //        yield return null;
    //    }
    //}

    //public IEnumerator AssingnKey(string KeyName)
    //{
    //    waitingForKey = true;

    //    yield return waitForkey();

    //    switch (KeyName)
    //    {
    //        case "forward":
    //            Debug.Log("Foewardas");
    //            GameManager.Gm.Forward = newkey;
    //            ButtonText.text = GameManager.Gm.Forward.ToString();
    //            PlayerPrefs.SetString("forwardKey", GameManager.Gm.Forward.ToString());
    //            break;
    //        case "backward":
    //            GameManager.Gm.Forward = newkey;
    //            ButtonText.text = GameManager.Gm.Forward.ToString();
    //            PlayerPrefs.SetString("backwardKey", GameManager.Gm.BackWard.ToString());
    //            break;
    //        case "left":
    //            GameManager.Gm.Forward = newkey;
    //            ButtonText.text = GameManager.Gm.Forward.ToString();
    //            PlayerPrefs.SetString("leftKey", GameManager.Gm.Left.ToString());
    //            break;
    //        case "right":
    //            GameManager.Gm.Forward = newkey;
    //            ButtonText.text = GameManager.Gm.Forward.ToString();
    //            PlayerPrefs.SetString("rightKey", GameManager.Gm.Right.ToString());
    //            break;
    //        case "interact":
    //            GameManager.Gm.Forward = newkey;
    //            ButtonText.text = GameManager.Gm.Forward.ToString();
    //            PlayerPrefs.SetString("interactKey", GameManager.Gm.Interact.ToString());
    //            break;
    //        default:
    //            break;
    //    }
    //    yield return null;


    //}


    /// <summary>
    /// Sets master volume
    /// </summary>
    /// <param name="volume"></param>
    public void SetVolume(float volume)
    {
        if (MainMixerParamaName != null)
        {
            audioMixer.SetFloat(MainMixerParamaName, volume);
        }
    }
    /// <summary>
    /// sets Other volume
    /// </summary>
    /// <param name="volume"></param>
    public void SetOtherVolume(float volume)
    {
        if (AudioParameterName1 != null)
        {
            audioMixer.SetFloat(AudioParameterName1, volume);
        }
    }

    public void SetOtherOtherVolume(float volume)
    {
        if (AudioParameterName2 != null)
        {
            audioMixer.SetFloat(AudioParameterName2, volume);
        }
    }

    public void PlayAudioVolumeidecater(int Number)
    {

        switch (Number)
        {
            case 1:
                audio.outputAudioMixerGroup = audioMixerGroup[0];
               
                audio.Play();
                break;
            case 2:
                audio.outputAudioMixerGroup = audioMixerGroup[1];
                audio.Play();
                break;
            case 3:
                audio.outputAudioMixerGroup = audioMixerGroup[2];
                audio.Play();
                break;
            case 4:
                audio.outputAudioMixerGroup = audioMixerGroup[3];
                audio.Play();
                break;
            default:
                break;
        }
        Debug.Log("lalal");
        audio.Play();
    }

    /// <summary>
    /// set graphicKvality
    /// </summary>
    /// <param name="i"></param>
    public void SetQuvality(int i)
    {
        GraphicsQvality = i;


        Debug.Log("kvality");
    }

    public void SetFullScreen(bool isFullscreem)
    {
        Screen.fullScreen = isFullscreem;
    }

    /// <summary>
    /// finds person screen resolition for persons computer
    /// </summary>
    public void Resolution()
    {
        ScreenResolutions = Screen.resolutions;
        ResolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < ScreenResolutions.Length; i++)
        {
            if (i >= 1)
            {
                if (ScreenResolutions[i - 1].height != ScreenResolutions[i].height && ScreenResolutions[i - 1].width != ScreenResolutions[i].width)
                {
                    string option = ScreenResolutions[i].width + " X " + ScreenResolutions[i].height;
                    GameResolutions.Add(ScreenResolutions[i]);
                    options.Add(option);
                }
            }
            if (ScreenResolutions[i].width == Screen.currentResolution.width && ScreenResolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        ResolutionDropdown.AddOptions(options);
        ResolutionDropdown.value = currentResolutionIndex;
        ResolutionDropdown.RefreshShownValue();
    }
    /// <summary>
    /// sets Resoliution
    /// </summary>
    /// <param name="resolutionIndex"></param>
    public void setResolution(int resolutionIndex)
    {

        Debug.Log("resolution index: " + resolutionIndex);

        GameResolution = GameResolutions[resolutionIndex];
        //   GameResolution = ScreenResolutions[resolutionIndex];

        Debug.Log(GameResolution.height + " " + GameResolution.width);

    }

    /// <summary>
    /// for aplly button
    /// </summary>
    public void Apply()
    {
        Screen.SetResolution(GameResolution.width, GameResolution.height, Screen.fullScreen);
        QualitySettings.SetQualityLevel(GraphicsQvality);

    }
    /// <summary>
    /// Lord Main Menu
    /// </summary>
    public void MainMenu()
    {

        SceneManager.LoadScene("MainMenu");
    }



}
