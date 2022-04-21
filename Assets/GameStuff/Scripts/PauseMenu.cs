using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuBackerIU;

    public static bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ResumeGame()
    {
        PauseMenuBackerIU.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }

    void PauseGAme()
    {
        PauseMenuBackerIU.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void QuitGameToDesktop()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGAme();
            }
        }
    }
}
