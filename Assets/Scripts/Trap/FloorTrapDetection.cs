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

    //При входе игрока в зону триггера вызывает метод ShowTrap для смены цвета ловушки с дефолтного на оранжевый
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
            ShowTrap();
    }

    //При выходе игрока из зоны триггера вызывает метод HideTrap для смены цвета ловушки с оранжевого на дефолтный
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
            HideTrap();
    }

    //Перебирает все элементы из которых состоит подвижная часть ловушки и задает оранжевый материал
    private void ShowTrap()
    {
        foreach (Renderer trapElement in trapElements)
            trapElement.material = trapDetectedMat;
    }

    //Перебирает все элементы из которых состоит подвижная часть ловушки и задает дефолтный материал
    private void HideTrap()
    {
        foreach (Renderer trapElement in trapElements)
            trapElement.material = trapHiddenMat;
    }
}
