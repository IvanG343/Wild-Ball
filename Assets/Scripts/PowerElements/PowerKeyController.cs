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

    //���������, ��� ����� ��������� � �������� ����� �����
    //�������� ����� ChangePlayerColor �� ������� PlayerController, ����� ������ ������ ����� ������� ��������������� ���������� ����� �����
    //�������� ����� HideActionTip ������� UIController ��� ������� ��������� "������� � ��� ��������������" ����� ���� ��� ����� ������� ������ ���� ��������
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

    //���������, ��� �������� ������ �� ������������� ��������� ����� �����, ����� ����� �� ��� ������� � � �������� ���������� �������� � ���� ���������
    //�������� ����� ShowActionTip ������� UIController ��� ����������� ��������� "������� � ��� ��������������"
    //����� ����, ��� ����� � ���� ��������
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag != other.gameObject.tag)
        {
            uiController.ShowActionTip();
            playerInArea = true;
        }
    }

    //�������� ����� HideActionTip ������� UIController ��� ������� ��������� "������� � ��� ��������������", ���� ����� ����� �� ��������
    //����� ����, ��� ����� ������� ���� ��������
    private void OnTriggerExit(Collider other)
    {
        uiController.HideActionTip();
        playerInArea = false;
    }

}
