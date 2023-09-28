using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject actionTipPanel;
    [SerializeField] private GameObject finishLevelMessage;

    [SerializeField] private Text greenNodeCountText;
    [SerializeField] private Text redNodeCountText;
    [SerializeField] private Text purpleNodeCountText;
    [SerializeField] private Text yellowNodeCountText;
    [SerializeField] private Text teleportIsOpenedText;

    //Отображает подсказку "Нажмите Е для взаимодействия"
    public void ShowActionTip()
    {
        actionTipPanel.SetActive(true);
    }

    //Скрывает подсказку "Нажмите Е для взаимодействия"
    public void HideActionTip()
    {
        actionTipPanel.SetActive(false);
    }

    //Выводит на экран надпись, что все ноды активированны и телепорт комната открыта
    public void ShowLevelCompleteMessage()
    {
        finishLevelMessage.SetActive(true);
    }

    //Обновляем значения кол-ва нод оставшихся на уровне на экране паузы
    public void UpdateNodeCounterText(int green, int red, int purple, int yellow)
    {
        Debug.Log($"UpdateNodeCounterText green {green}, red {red}, purple {purple}, yellow {yellow}");
        greenNodeCountText.text = green.ToString();
        redNodeCountText.text = red.ToString();
        purpleNodeCountText.text = purple.ToString();
        yellowNodeCountText.text = yellow.ToString();
    }

    //Обновляем текст на экране паузы, что комната телепорт открыта
    public void TeleportIsOpenedMessage()
    {
        teleportIsOpenedText.text = "Teleport room: Open";
    }
}
