using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class MainMenu : MonoBehaviour
{
    public GameObject Menu;
    public GameObject HowToPlayMenu;
    public GameObject AboutMenu;
    public GameObject SettingsMenu;
    public TextMeshProUGUI pairCount;
    public Button MusicButton;
    public AudioSource backgroundMusic;

    private void Awake()
    {
        Menu.SetActive(true);
        HowToPlayMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        AboutMenu.SetActive(false);
    }
    private void Update()
    {
        Globals.levelPairCount = Int16.Parse(pairCount.text);
        switch (Globals.levelPairCount)
        {
            case 1:
                Globals.time = 60;
                break;
            case 2:
                Globals.time = 75;
                break;
            case 3:
                Globals.time = 90;
                break;
        }
    }

    public void OnPlayClicked()
    {
        Menu.SetActive(false);
        HowToPlayMenu.SetActive(true);
    }

    public void OnContinueClick()
    {
        Globals.paused = false;
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void OnSettingsClick()
    {
        Menu.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    public void OnAboutClick()
    {
        Menu.SetActive(false);
        AboutMenu.SetActive(true);
    }

    public void OnBackClick()
    {
        Menu.SetActive(true);
        HowToPlayMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        AboutMenu.SetActive(false);
    }

    public void OnMusicVolumeClick()
    {
        //toggle the background music on or off for the game
        if (Globals.musicVolume == true)
        {
            backgroundMusic.Stop();
            MusicButton.GetComponentInChildren<TextMeshProUGUI>().text = "Music Volume: OFF";
            Globals.musicVolume = false;
        }
        else
        {
            backgroundMusic.Play();
            MusicButton.GetComponentInChildren<TextMeshProUGUI>().text = "Music Volume: ON";
            Globals.musicVolume = true;
        }
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }
}