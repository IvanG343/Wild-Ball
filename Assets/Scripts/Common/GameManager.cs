using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TeleportRoom teleportRoom;
    [SerializeField] private UIController uiController;

    //Кол-во нод на уровне
    public int totalNodes;

    //Считаем изначальное общее кол-во нод на уровне
    private void Start()
    {
        //totalNodes = greenNodes + redNodes + purpleNodes + yellowNodes;
    }

    //Проверяем общее кол-во нод и если их становится 0, открываем комнату телепорт
    //Выводим подсказку на экран через скрипт UIController
    private void Update()
    {
        if (totalNodes == 0)
        {
            totalNodes = -1; //Ставим значение -1, чтобы условие в апдейте больше не выполнялось.
            teleportRoom.OpenTeleportRoom();
            uiController.ShowLevelCompleteMessage();
        }
    }
}

