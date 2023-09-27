using UnityEngine;

public class MenuHandler : MonoBehaviour
{

    [SerializeField] public GameObject pausePanel;
    [SerializeField] public SceneController sceneController;

    //Вызов меню паузы
    public void OnClickPauseButton()
    {
        Time.timeScale = 0;
        if(!pausePanel.activeSelf)
        {
            pausePanel.SetActive(true);
        }
    }

    //Вовзрат в игру из меню паузы
    public void OnClickResumeButton()
    {
        Time.timeScale = 1;
        if (pausePanel.activeSelf)
        {
            pausePanel.SetActive(false);
        }
    }

    //Перезапуск уровня из меню паузы
    public void OnClickRestartButton()
    {
        Time.timeScale = 1.0F;
        sceneController.RestartCurrentLevel();
    }

    //Выход в главное меню из меню паузы
    public void OnClickPauseExitButton()
    {
        Time.timeScale = 1.0F;
        sceneController.LoadLevel(0);
    }

    //Выбор уровня в главном меню, вызывает метод LoadLevel в скрипте SceneController с указанным ID
    public void OnClickSelectLevel(int id)
    {
        sceneController.LoadLevel(id);
    }

}
