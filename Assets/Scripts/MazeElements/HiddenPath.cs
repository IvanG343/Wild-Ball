using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenPath : MonoBehaviour
{
    [SerializeField] private Material pathHiddenMat;
    [SerializeField] private Material pathDetectedMat;

    private Renderer path;

    private void Start()
    {
        path = GetComponentInChildren<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            ShowPath();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            HidePath();
        }
    }

    private void ShowPath()
    {
        path.material = pathDetectedMat;
    }

    private void HidePath()
    {
        path.material = pathHiddenMat;
    }
}
