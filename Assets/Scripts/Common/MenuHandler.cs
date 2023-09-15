using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{

    public GameObject pausePanel;

    void Start()
    {
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        
    }

    public void OnClickSelectLevel(int id)
    {
        SceneManager.LoadScene(id);
    }

    public void OnClickPauseButton()
    {
        Time.timeScale = 0;
        if(!pausePanel.activeSelf)
        {
            pausePanel.SetActive(true);
        }
    }

    public void OnClickResumeButton()
    {
        Time.timeScale = 1;
        if (pausePanel.activeSelf)
        {
            pausePanel.SetActive(false);
        }
    }

    public void OnClickRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnClickPauseExitButton()
    {
        SceneManager.LoadScene(0);
    }

}
