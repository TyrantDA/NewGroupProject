using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuBackerIU;
    public GameObject OptionMenuBackerIU;

    public static bool isPaused = false;
    public static bool isOption = false;

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

    public void Options()
    {
        PauseMenuBackerIU.SetActive(false);
        OptionMenuBackerIU.SetActive(true);
        isOption = true;
    }

    public void QUitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("throneroomanddoors");
    }
    public void QuitGameToDesktop()
    {
        Application.Quit();
    }

    public void Back()
    {
        PauseMenuBackerIU.SetActive(true);
        OptionMenuBackerIU.SetActive(false);
        isOption = false;
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                if (isOption)
                {
                    PauseMenuBackerIU.SetActive(true);
                    OptionMenuBackerIU.SetActive(false);
                    isOption = false;
                }
                else
                {
                    ResumeGame();
                }
            }
            else
            {
                PauseGAme();
            }
        }
    }
}
