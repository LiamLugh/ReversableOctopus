using System.Collections;
using TMPro;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject mainMenu;
    public GameObject countdownCanvas;
    public Ship ship;

    void Update()
    {
        if (Globals.paused == true)
        {
            mainMenu.SetActive(false);
        }
        else
        {
            mainMenu.SetActive(true);
        }
    }

    public void onbuttonClick()
    {
        menu.SetActive(true);
        ship.pauseVelocity();
        Globals.paused = true;
    }

    public void OnResumeClick()
    {
        menu.SetActive(false);
        StartCoroutine(ResumeGame(3));
    }

    public void OnMainMenuClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }

    private IEnumerator ResumeGame(float time)
    {
        countdownCanvas.SetActive(true);
        TextMeshProUGUI text = countdownCanvas.GetComponentInChildren<TextMeshProUGUI>();
        float elapsedTime = 0;

        //loops until time is up then toggles the canvas and resumes game
        while (elapsedTime / time < 1)
        {
            int counter = 3 - (int)elapsedTime;
            text.text = counter.ToString();
            yield return new WaitForEndOfFrame();

            elapsedTime += Time.deltaTime;
        }
        countdownCanvas.SetActive(false);
        Globals.paused = false;
        ship.resumeVelocity();
    }
}