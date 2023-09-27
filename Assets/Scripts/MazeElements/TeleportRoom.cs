using UnityEngine;

public class TeleportRoom : MonoBehaviour
{

    [SerializeField] private GameObject teleportRoom;
    [SerializeField] private Animation doorAnimation;

    //Вызывается из GameManager при условии, что все ноды на уровне активированны
    //Включет ранее невидимую комнату телепорт и проигрывает анимацию "уезжания" двери вниз
    public void OpenTeleportRoom()
    {
        teleportRoom.SetActive(true);
        doorAnimation.Play();
    }

}
