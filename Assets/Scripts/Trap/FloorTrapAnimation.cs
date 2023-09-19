using UnityEngine;

public class FloorTrap : MonoBehaviour
{
    private Animator trapAnimation;

    private void Start()
    {
        trapAnimation = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
            trapAnimation.SetBool("IsDetected", true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
            trapAnimation.SetBool("IsDetected", false);
    }
}
