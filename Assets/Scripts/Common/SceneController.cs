using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private Animator animator;
    private int levelIndex;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    //��������� �������� ���������� ������ ��� �������� �� ����� �������
    public void FadeToLevelAnimation()
    {
        animator.SetTrigger("FadeOut");
    }

    //���������� ������� � ����� ��������
    //�������� ����� LoadScene � ��������� ID
    //���� ������������ ID ���� ��� ����. ID � ���������� �����, �� ��������� ������� ������� ��������
    public void OnFadeAnimationComplete()
    {
        if (levelIndex > SceneManager.sceneCountInBuildSettings -1)
            levelIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(levelIndex);
    }

    //��������� ���������� ������� �� ID, ���������� �� �������� ���� � ������ ������ �������
    //�������� ����� FadeToLevelAnimation ������� � ���� ������� �������� ����� OnFadeAnimationComplete ������� ��� ���������������� ������ ����� �� ID
    public void LoadLevel(int id)
    {
        levelIndex = id;
        FadeToLevelAnimation();
    }

    //��������� ��������� �� ����� �������
    //�������� ����� FadeToLevelAnimation ������� � ���� ������� �������� ����� OnFadeAnimationComplete ������� ��� ���������������� ������ ����� �� ID
    public void LoadNextLevel()
    {
        levelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        FadeToLevelAnimation();
    }

    //������������� ������� �������
    //�������� ����� FadeToLevelAnimation ������� � ���� ������� �������� ����� OnFadeAnimationComplete ������� ��� ���������������� ������ ����� �� ID
    public void RestartCurrentLevel()
    {
        levelIndex = SceneManager.GetActiveScene().buildIndex;
        FadeToLevelAnimation();
    }
}
