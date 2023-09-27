using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject actionTipPanel;
    [SerializeField] private GameObject finishLevelMessage;
    [SerializeField] private Text greenNodesCountText;
    [SerializeField] private Text redNodesCountText;
    [SerializeField] private Text purpleNodesCountText;
    [SerializeField] private Text yellowNodesCountText;

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
