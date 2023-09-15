using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{

    public Material trapHidden;
    public Material trapDetected;

    public Renderer[] cubesMaterial;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
            ChangeTrapColor(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
            ChangeTrapColor(false);
    }

    private void ChangeTrapColor(bool isDetected)
    {
        if (isDetected)
            for (int i = 0; i < cubesMaterial.Length; i++)
                cubesMaterial[i].material = trapDetected;
        else
            for (int i = 0; i < cubesMaterial.Length; i++)
                cubesMaterial[i].material = trapHidden;
    }

}
