using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject teleportRoom;
    [SerializeField] private GameObject teleportRoomDoor;

    public int totalCubes;
    public static int cubesToWin;

    private void Awake()
    {
        cubesToWin = totalCubes;
    }

    private void Update()
    {
        if (cubesToWin == 0)
        {
            cubesToWin = -1;
            OpenTeleportRoom();
        }
    }

    private void OpenTeleportRoom()
    {
        teleportRoom.SetActive(true);
        teleportRoomDoor.SetActive(false);
    }
}

