using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TeleportRoom teleportRoom;
    [SerializeField] private GameObject stageCompleteWindow;

    public int totalNodesOnLevel;
    public static int nodesToWin;

    private void Start()
    {
        nodesToWin = totalNodesOnLevel;
    }

    private void Update()
    {
        if (nodesToWin == 0)
        {
            nodesToWin = -1;
            teleportRoom.OpenTeleportRoom();
            ShowStageComleteWindow();
        }
    }

    private void ShowStageComleteWindow()
    {
        stageCompleteWindow.SetActive(true);
    }
}

