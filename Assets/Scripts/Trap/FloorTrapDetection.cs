using UnityEngine;

public class FloorTrapDetection : MonoBehaviour
{
    [SerializeField] private Material trapHiddenMat;
    [SerializeField] private Material trapDetectedMat;

    private Renderer[] trapElements;

    private void Start()
    {
        trapElements = gameObject.transform.Find("ActiveElements").GetComponentsInChildren<Renderer>();
    }

    //��� ����� ������ � ���� �������� �������� ����� ShowTrap ��� ����� ����� ������� � ���������� �� ���������
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
            ShowTrap();
    }

    //��� ������ ������ �� ���� �������� �������� ����� HideTrap ��� ����� ����� ������� � ���������� �� ���������
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
            HideTrap();
    }

    //���������� ��� �������� �� ������� ������� ��������� ����� ������� � ������ ��������� ��������
    private void ShowTrap()
    {
        foreach (Renderer trapElement in trapElements)
            trapElement.material = trapDetectedMat;
    }

    //���������� ��� �������� �� ������� ������� ��������� ����� ������� � ������ ��������� ��������
    private void HideTrap()
    {
        foreach (Renderer trapElement in trapElements)
            trapElement.material = trapHiddenMat;
    }
}
