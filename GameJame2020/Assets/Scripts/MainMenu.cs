using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Menu;
    public GameObject AboutMenu;
    public GameObject SettingsMenu;

    public Button MusicButton;
    public AudioSource backgroundMusic;

    private void Awake()
    {
        Menu.SetActive(true);
        SettingsMenu.SetActive(false);
        AboutMenu.SetActive(false);
    }
    public void OnPlayClicked()
    {
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