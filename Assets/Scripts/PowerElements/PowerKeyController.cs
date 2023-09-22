using UnityEngine;

public class PowerKeyController : MonoBehaviour
{
    private PlayerController playerController;
    private UIController uiController;

    private AudioSource useSound;

    private bool playerInArea;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        uiController = GameObject.Find("UICanvas").GetComponent<UIController>();
        useSound = GetComponentInChildren<AudioSource>();
    }

    private void Update()
    {
        if (playerInArea)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                playerController.ChangePlayerColor(gameObject.tag);
                useSound.Play();
                playerInArea = false;
                uiController.HideActionTip();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag != other.gameObject.tag)
        {
            uiController.ShowActionTip();
            playerInArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        uiController.HideActionTip();
        playerInArea = false;
    }

}
