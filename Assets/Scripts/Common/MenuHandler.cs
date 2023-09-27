using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private SceneController sceneController;

    [SerializeField] private Image soundCheckbox;
    [SerializeField] private Image musicCheckbox;
    [SerializeField] private Sprite checkboxSpriteTrue;
    [SerializeField] private Sprite checkboxSpriteFalse;

    private bool soundState = true;
    private bool musicState = true;

    private bool isPauseScreen = false;

    //Вызов меню паузы по нажатию Escape
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPauseScreen)
                OnClickPauseButton();
            else
                OnClickResumeButton();
        }
    }

    //Вызов меню паузы
    public void OnClickPauseButton()
    {
        Time.timeScale = 0;
        if (!pausePanel.activeSelf)
        {
            pausePanel.SetActive(true);
            isPauseScreen = true;
        }
    }

    //Вовзрат в игру из меню паузы
    public void OnClickResumeButton()
    {
        Time.timeScale = 1;
        if (pausePanel.activeSelf)
        {
            pausePanel.SetActive(false);
            isPauseScreen = false;
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

    //Вкл-выкл звук (пока что функция не выключает звук, только визуал кнопок)
    public void SoundControl()
    {
        if (soundState)
        {
            soundCheckbox.sprite = checkboxSpriteFalse;
            soundState = false;
        }
        else
        {
            soundCheckbox.sprite = checkboxSpriteTrue;
            soundState = true;
        }
    }

    //Вкл-выкл музыку (пока что функция не выключает звук, только визуал кнопок)
    public void MusicControl()
    {
        if (musicState)
        {
            musicCheckbox.sprite = checkboxSpriteFalse;
            musicState = false;
        }
        else
        {
            musicCheckbox.sprite = checkboxSpriteTrue;
            musicState = true;
        }
    }

    //Выход из приложения
    public void OnClickExitGameButton()
    {
        Application.Quit();
    }
}
