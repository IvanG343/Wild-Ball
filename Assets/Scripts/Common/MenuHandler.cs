using UnityEngine;

public class MenuHandler : MonoBehaviour
{

    [SerializeField] public GameObject pausePanel;
    [SerializeField] public SceneController sceneController;

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

    public void OnClickSelectLevel(int id)
    {
        sceneController.LoadLevel(id);
    }

    public void OnClickRestartButton()
    {
        Time.timeScale = 1.0F;
        sceneController.RestartCurrentLevel();
    }

    public void OnClickPauseExitButton()
    {
        Time.timeScale = 1.0F;
        sceneController.LoadLevel(0);
    }

}
