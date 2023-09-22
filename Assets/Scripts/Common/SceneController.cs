using UnityEditor.PackageManager;
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

    public void FadeToLevelAnimation()
    {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeAnimationComplete()
    {
        if (levelIndex > SceneManager.sceneCountInBuildSettings)
            levelIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(levelIndex);
    }

    public void LoadLevel(int id)
    {
        levelIndex = id;
        FadeToLevelAnimation();
    }

    public void LoadNextLevel()
    {
        levelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        FadeToLevelAnimation();
    }

    public void RestartCurrentLevel()
    {
        levelIndex = SceneManager.GetActiveScene().buildIndex;
        FadeToLevelAnimation();
    }
}
