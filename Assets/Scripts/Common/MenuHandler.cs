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

    //����� ���� ����� �� ������� Escape
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

    //����� ���� �����
    public void OnClickPauseButton()
    {
        Time.timeScale = 0;
        if (!pausePanel.activeSelf)
        {
            pausePanel.SetActive(true);
            isPauseScreen = true;
        }
    }

    //������� � ���� �� ���� �����
    public void OnClickResumeButton()
    {
        Time.timeScale = 1;
        if (pausePanel.activeSelf)
        {
            pausePanel.SetActive(false);
            isPauseScreen = false;
        }
    }

    //���������� ������ �� ���� �����
    public void OnClickRestartButton()
    {
        Time.timeScale = 1.0F;
        sceneController.RestartCurrentLevel();
    }

    //����� � ������� ���� �� ���� �����
    public void OnClickPauseExitButton()
    {
        Time.timeScale = 1.0F;
        sceneController.LoadLevel(0);
    }

    //����� ������ � ������� ����, �������� ����� LoadLevel � ������� SceneController � ��������� ID
    public void OnClickSelectLevel(int id)
    {
        sceneController.LoadLevel(id);
    }

    //���-���� ���� (���� ��� ������� �� ��������� ����, ������ ������ ������)
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

    //���-���� ������ (���� ��� ������� �� ��������� ����, ������ ������ ������)
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

    //����� �� ����������
    public void OnClickExitGameButton()
    {
        Application.Quit();
    }
}
