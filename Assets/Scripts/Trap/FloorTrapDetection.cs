using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTrapDetection : MonoBehaviour
{
    [SerializeField] private Material trapHiddenMat;
    [SerializeField] private Material trapDetectedMat;

    private Renderer[] trapElements;

    private void Start()
    {
        trapElements = gameObject.transform.Find("ActiveElements").GetComponentsInChildren<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            ShowTrap();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            HideTrap();
        }
    }

    private void ShowTrap()
    {
        foreach (Renderer trapElement in trapElements)
            trapElement.material = trapDetectedMat;
    }

    private void HideTrap()
    {
        foreach (Renderer trapElement in trapElements)
            trapElement.material = trapHiddenMat;
    }
}
