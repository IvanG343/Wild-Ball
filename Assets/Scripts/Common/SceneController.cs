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

    //Запускает анимацию затемнения экрана для перехода на новый уровень
    public void FadeToLevelAnimation()
    {
        animator.SetTrigger("FadeOut");
    }

    //Вызывается ивентом в конце анимации
    //Вызывает метод LoadScene с указанным ID
    //Если передаваемый ID выше чем макс. ID в настройках билда, то загружает текущий уровень повторно
    public void OnFadeAnimationComplete()
    {
        if (levelIndex > SceneManager.sceneCountInBuildSettings -1)
            levelIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(levelIndex);
    }

    //Загружает конкретный уровень по ID, вызывается из главного меню с экрана выбора уровней
    //Вызывает метод FadeToLevelAnimation который в свою очередь вызывает метод OnFadeAnimationComplete который уже непосредтственно грузит сцену по ID
    public void LoadLevel(int id)
    {
        levelIndex = id;
        FadeToLevelAnimation();
    }

    //Загружает следующий по счёту уровень
    //Вызывает метод FadeToLevelAnimation который в свою очередь вызывает метод OnFadeAnimationComplete который уже непосредтственно грузит сцену по ID
    public void LoadNextLevel()
    {
        levelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        FadeToLevelAnimation();
    }

    //Перезапускает текущий уровень
    //Вызывает метод FadeToLevelAnimation который в свою очередь вызывает метод OnFadeAnimationComplete который уже непосредтственно грузит сцену по ID
    public void RestartCurrentLevel()
    {
        levelIndex = SceneManager.GetActiveScene().buildIndex;
        FadeToLevelAnimation();
    }
}
