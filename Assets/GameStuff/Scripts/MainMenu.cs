using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mainMenuUI;
    public GameObject AchievementUI;
    public GameObject spawnPoint;
    public GameObject OptionMenuBackerIU;
    public GameObject ControlsUI;

    bool AchievementOn = false;
    bool isOption = false;
    bool isControls = false;

    void Start()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("AlexStroy");
    }

    public void Achievement()
    {
        AchievementOn = true;
        mainMenuUI.SetActive(false);
        OptionMenuBackerIU.SetActive(false);
        AchievementUI.SetActive(true);
    }
    IEnumerator unlock()
    {
        spawnPoint.SetActive(true);
        yield return new WaitForSeconds(5);
        spawnPoint.SetActive(false);
    }

    public void dontPress()
    {
        int achieve = PlayerPrefs.GetInt("Don't click here", 0);
        if (achieve == 0)
        {
            PlayerPrefs.SetInt("Don't click here", 2);
            StartCoroutine("unlock");
        }
    }

    public void Options()
    {
        isOption = true;
        OptionMenuBackerIU.SetActive(true);
    }

    public void Back()
    {
        OptionMenuBackerIU.SetActive(false);
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Controls()
    {
        ControlsUI.SetActive(true);
        isControls = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (AchievementOn)
            {
                mainMenuUI.SetActive(true);
                AchievementUI.SetActive(false);
                AchievementOn = false;
            }
            else if(isOption)
            {
                if (isControls)
                {
                    ControlsUI.SetActive(false);
                    isControls = false;
                }
                else
                {
                    Back();
                }
            }

        }
    }
}
