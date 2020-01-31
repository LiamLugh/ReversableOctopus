using System.Collections;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public int timeLeft = 60;
    public TextMeshProUGUI countdown;

    void Start()
    {
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
            if(Globals.paused == false)
            {
                yield return new WaitForSeconds(1);
                timeLeft--;
            }
        }

        //here we simply go to a lose state because a win state hasnt been triggered beforehand
        Globals.win = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("WinLose");
    }
}