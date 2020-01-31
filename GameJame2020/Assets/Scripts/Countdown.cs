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
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}