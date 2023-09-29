using UnityEngine;

public class PowerKeyController : MonoBehaviour
{
    private PlayerController playerController;
    private UIController uiController;

    private bool playerInArea;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        uiController = GameObject.Find("UICanvas").GetComponent<UIController>();
    }

    //Проверяем, что игрок находится в триггере сферы ключа
    //Вызываем метод ChangePlayerColor из скрипта PlayerController, чтобы задать игроку новый мтариал соответствующий материалку сферы ключа
    //Вызывает метод HideActionTip скрипта UIController для скрытия подсказки "Нажмите Е для взаимодействия" после того как игрок успешно сменил свой материал
    private void Update()
    {
        if (playerInArea)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                playerController.ChangePlayerColor(gameObject.tag);
                playerInArea = false;
                uiController.HideActionTip();
            }
        }
    }

    //Проверяем, что материал игрока НЕ соответствует материалу сферы ключа, чтобы игрок не мог спамить Е и вызывать бесконечно анимацию и звук активации
    //Вызывает метод ShowActionTip скрипта UIController для отображения подсказки "Нажмите Е для взаимодействия"
    //Задаём флаг, что игрок в зоне триггера
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag != other.gameObject.tag)
        {
            uiController.ShowActionTip();
            playerInArea = true;
        }
    }

    //Вызывает метод HideActionTip скрипта UIController для скрытия подсказки "Нажмите Е для взаимодействия", если игрок вышел из триггера
    //Задаём флаг, что игрок покинул зону триггера
    private void OnTriggerExit(Collider other)
    {
        uiController.HideActionTip();
        playerInArea = false;
    }

}
