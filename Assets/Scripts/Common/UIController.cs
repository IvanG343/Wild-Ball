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

    //��������� �������� ���-�� ��� ���������� �� ������ �� ������ �����
    public void UpdateNodeCounterText(int green, int red, int purple, int yellow)
    {
        Debug.Log($"UpdateNodeCounterText green {green}, red {red}, purple {purple}, yellow {yellow}");
        greenNodeCountText.text = green.ToString();
        redNodeCountText.text = red.ToString();
        purpleNodeCountText.text = purple.ToString();
        yellowNodeCountText.text = yellow.ToString();
    }

    //��������� ����� �� ������ �����, ��� ������� �������� �������
    public void TeleportIsOpenedMessage()
    {
        teleportIsOpenedText.text = "Teleport room: Open";
    }
}
