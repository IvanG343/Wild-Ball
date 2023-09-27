using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TeleportRoom teleportRoom;
    [SerializeField] private UIController uiController;

    //���-�� ��� �� ������
    public int totalNodes;

    //������� ����������� ����� ���-�� ��� �� ������
    private void Start()
    {
        //totalNodes = greenNodes + redNodes + purpleNodes + yellowNodes;
    }

    //��������� ����� ���-�� ��� � ���� �� ���������� 0, ��������� ������� ��������
    //������� ��������� �� ����� ����� ������ UIController
    private void Update()
    {
        if (totalNodes == 0)
        {
            totalNodes = -1; //������ �������� -1, ����� ������� � ������� ������ �� �����������.
            teleportRoom.OpenTeleportRoom();
            uiController.ShowLevelCompleteMessage();
        }
    }
}

