using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public TeleportRoom teleportRoom;

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
            teleportRoom.OpenTeleportRoom();
        }
    }
}

