using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTrap : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
            anim.SetBool("PlayAnimation", true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
            anim.SetBool("PlayAnimation", false);
    }
}
