using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    public GameObject win;
    public GameObject lose;

    void Awake()
    {
        //decide which canvas to display
        /*if(win){
        win.SetActive(true);
        lose.SetActive(false);
        }else{
        win.SetActive(false);
        lose.SetActive(true);
        }
    */
    }

    public void OnContinueClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
