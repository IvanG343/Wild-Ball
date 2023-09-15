using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportRoom : MonoBehaviour
{

    [SerializeField] private GameObject teleportRoom;
    [SerializeField] private Animation doorAnimation;


    public void OpenTeleportRoom()
    {
        teleportRoom.SetActive(true);
        doorAnimation.Play();
    }

}
