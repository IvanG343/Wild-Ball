using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TeleportRoom teleportRoom;
    [SerializeField] private UIController uiController;

    //Кол-во нод на уровне
    public int totalNodes;
    public int greenNodes;
    public int redNodes;
    public int purpleNodes;
    public int yellowNodes;

    //Считаем изначальное общее кол-во нод на уровне
    private void Start()
    {
        totalNodes = greenNodes + redNodes + purpleNodes + yellowNodes;
        uiController.UpdateNodeCounterText(greenNodes, redNodes, purpleNodes, yellowNodes);
    }

    //Метод вызывается из скрипта PowerNodeController при активации ноды и убирает её из списка
    //Вызывает метод UpdateNodeCounterText скрипта UIController, чтобы обновить значения кол-ва нод оставшихся на уровне
    public void ExcludeNodeFromCounter(string color)
    {
        Debug.Log("ExcludeNodeFromCounter" + color);
        switch (color)
        {
            case "Green":
                greenNodes--;
                break;
            case "Red":
                redNodes--;
                break;
            case "Purple":
                purpleNodes--;
                break;
            case "Yellow":
                yellowNodes--;
                break;
        }
        totalNodes--;
        uiController.UpdateNodeCounterText(greenNodes, redNodes, purpleNodes, yellowNodes);
    }

    //Проверяем общее кол-во нод и если их становится 0, открываем комнату телепорт
    //Выводим подсказку на экран через скрипт UIController так же меняет сообщение на экране пазуы, что комната телепорт открыта
    private void Update()
    {
        if (totalNodes == 0)
        {
            totalNodes = -1; //Ставим значение -1, чтобы условие в апдейте больше не выполнялось.
            teleportRoom.OpenTeleportRoom();
            uiController.ShowLevelCompleteMessage();
            uiController.TeleportIsOpenedMessage();
        }
    }
}

