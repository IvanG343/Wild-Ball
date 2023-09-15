using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PowerKeyController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject ActionTipPanel;
    private AudioSource useSound;

    private bool playerInArea;

    private void Start()
    {
        useSound = GetComponentInParent<AudioSource>();
    }

    private void Update()
    {
        if (playerInArea)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                playerController.ChangePlayerColor(gameObject.tag);
                useSound.Play();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag != other.gameObject.tag)
        {
            ShowActionTooltip();
            playerInArea = true;
        }


    }

    private void OnTriggerExit(Collider other)
    {
        HideActionTooltip();
        playerInArea = false;
    }

    public void ShowActionTooltip()
    {
        ActionTipPanel.SetActive(true);
    }

    public void HideActionTooltip()
    {
        ActionTipPanel.SetActive(false);
    }

}
