using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject actionTipPanel;
    [SerializeField] private GameObject finishLevelMessage;

    //���������� ��������� "������� � ��� ��������������"
    public void ShowActionTip()
    {
        actionTipPanel.SetActive(true);
    }

    //�������� ��������� "������� � ��� ��������������"
    public void HideActionTip()
    {
        actionTipPanel.SetActive(false);
    }

    //������� �� ����� �������, ��� ��� ���� ������������� � �������� ������� �������
    public void ShowLevelCompleteMessage()
    {
        finishLevelMessage.SetActive(true);
    }
}
