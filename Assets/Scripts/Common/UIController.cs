using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject actionTipPanel;
    [SerializeField] private GameObject finishLevelMessage;

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
}
