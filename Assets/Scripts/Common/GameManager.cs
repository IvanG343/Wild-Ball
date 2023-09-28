using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TeleportRoom teleportRoom;
    [SerializeField] private UIController uiController;

    //���-�� ��� �� ������
    public int totalNodes;
    public int greenNodes;
    public int redNodes;
    public int purpleNodes;
    public int yellowNodes;

    //������� ����������� ����� ���-�� ��� �� ������
    private void Start()
    {
        totalNodes = greenNodes + redNodes + purpleNodes + yellowNodes;
        uiController.UpdateNodeCounterText(greenNodes, redNodes, purpleNodes, yellowNodes);
    }

    //����� ���������� �� ������� PowerNodeController ��� ��������� ���� � ������� � �� ������
    //�������� ����� UpdateNodeCounterText ������� UIController, ����� �������� �������� ���-�� ��� ���������� �� ������
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

    //��������� ����� ���-�� ��� � ���� �� ���������� 0, ��������� ������� ��������
    //������� ��������� �� ����� ����� ������ UIController ��� �� ������ ��������� �� ������ �����, ��� ������� �������� �������
    private void Update()
    {
        if (totalNodes == 0)
        {
            totalNodes = -1; //������ �������� -1, ����� ������� � ������� ������ �� �����������.
            teleportRoom.OpenTeleportRoom();
            uiController.ShowLevelCompleteMessage();
            uiController.TeleportIsOpenedMessage();
        }
    }
}

