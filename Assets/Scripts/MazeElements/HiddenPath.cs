using UnityEngine;

public class HiddenPath : MonoBehaviour
{
    [SerializeField] private Material pathHiddenMat;
    [SerializeField] private Material pathDetectedMat;

    private Renderer path;

    private void Start()
    {
        path = GetComponentInChildren<Renderer>();
    }

    //При входе в триггер проверяем, что вошёл именно игрок
    //Вызываем метод ShowPath для подсветки прохода
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            ShowPath();
        }
    }

    //При выходе из триггера проверяем, что вышёл именно игрок
    //Вызываем метод HidePath, чтобы вернуть изначальную текстуру
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            HidePath();
        }
    }

    //Меняет текстуру прохода на более светлую, обозначая скрытый проход когда игрок находится в триггере
    private void ShowPath()
    {
        path.material = pathDetectedMat;
    }

    //Возвращает изначальную текстуру скрытому проходу если игрок вышел из триггера
    private void HidePath()
    {
        path.material = pathHiddenMat;
    }
}
