using System.Collections;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    int timeLeft;
    public TextMeshProUGUI countdown;

    void Start()
    {
        timeLeft = Globals.time;
        StartCoroutine(LoseTime());
        Time.timeScale = 1;
    }

    void Update()
    {
        countdown.text = (timeLeft.ToString());
    }

    IEnumerator LoseTime()
    {
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1);
            if (Globals.paused == false)
            {
                
                timeLeft--;
            }
        }

        //here we simply go to a lose state because a win state hasnt been triggered beforehand
        Globals.win = false;
        //UnityEngine.SceneManagement.SceneManager.LoadScene("WinLose");
    }
}