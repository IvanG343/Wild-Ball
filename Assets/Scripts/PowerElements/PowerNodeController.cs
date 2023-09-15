using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class PowerNodeController : MonoBehaviour
{
    [SerializeField] private Material redMat;
    [SerializeField] private Material greenMat;
    [SerializeField] private Material purpleMat;
    [SerializeField] private Material yellowMat;

    [SerializeField] private GameObject actionTipPanel;

    private bool playerInArea;
    private string playerCurrentColor;

    private Renderer cubeMaterial;
    private Animator cubeAnimator;
    private AudioSource nodeUseSound;

    private void Start()
    {
        cubeMaterial = GetComponentInParent<Renderer>();
        cubeAnimator = GetComponentInParent<Animator>();
        nodeUseSound = GetComponentInParent<AudioSource>();
    }

    private void Update()
    {
        if (playerInArea)
        {
            if (Input.GetKeyDown(KeyCode.E))
                ChangeNodeColor(playerCurrentColor);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == other.gameObject.tag)
        {
            Debug.Log("enter");
            ShowActionTooltip();
            playerInArea = true;
            playerCurrentColor = other.gameObject.tag;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("exit");
        HideActionTooltip();
        playerInArea = false;
    }

    public void ChangeNodeColor(string color)
    {
        switch (color)
        {
            case "Yellow":
                cubeMaterial.material = yellowMat;
                cubeAnimator.SetTrigger("StartAnimation");
                nodeUseSound.Play();
                GameManager.cubesToWin--;
                break;
            case "Red":
                cubeMaterial.material = redMat;
                cubeAnimator.SetTrigger("StartAnimation");
                GameManager.cubesToWin--;
                nodeUseSound.Play();
                break;
            case "Green":
                cubeMaterial.material = greenMat;
                cubeAnimator.SetTrigger("StartAnimation");
                GameManager.cubesToWin--;
                nodeUseSound.Play();
                break;
            case "Purple":
                cubeMaterial.material = purpleMat;
                cubeAnimator.SetTrigger("StartAnimation");
                GameManager.cubesToWin--;
                nodeUseSound.Play();
                break;
            default: break;
        }
    }

    public void ShowActionTooltip()
    {
        actionTipPanel.SetActive(true);
    }

    public void HideActionTooltip()
    {
        actionTipPanel.SetActive(false);
    }

}