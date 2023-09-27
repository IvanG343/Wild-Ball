using UnityEngine;

public class TeleportRoom : MonoBehaviour
{

    [SerializeField] private GameObject teleportRoom;
    [SerializeField] private Animation doorAnimation;

    //���������� �� GameManager ��� �������, ��� ��� ���� �� ������ �������������
    //������� ����� ��������� ������� �������� � ����������� �������� "��������" ����� ����
    public void OpenTeleportRoom()
    {
        teleportRoom.SetActive(true);
        doorAnimation.Play();
    }

}
