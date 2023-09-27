using UnityEngine;

public class FloorTrap : MonoBehaviour
{
    private Animator trapAnimation;

    private void Start()
    {
        trapAnimation = GetComponent<Animator>();
    }

    //При входе игрока в тиггер запускаем анимацию напольной ловушки
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
            trapAnimation.SetBool("IsDetected", true);
    }

    //При выходе игрока из триггера возвращаем ловушке idle состояние
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
            trapAnimation.SetBool("IsDetected", false);
    }
}
