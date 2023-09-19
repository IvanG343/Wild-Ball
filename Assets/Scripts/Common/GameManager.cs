using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TeleportRoom teleportRoom;
    [SerializeField] private GameObject stageCompleteWindow;

    public int totalCubes;
    public static int cubesToWin;

    private void Start()
    {
        cubesToWin = totalCubes;
    }

    private void Update()
    {
        if (cubesToWin == 0)
        {
            cubesToWin = -1;
            teleportRoom.OpenTeleportRoom();
            ShowStageComleteWindow();
        }
    }

    private void ShowStageComleteWindow()
    {
        stageCompleteWindow.SetActive(true);
    }
}

