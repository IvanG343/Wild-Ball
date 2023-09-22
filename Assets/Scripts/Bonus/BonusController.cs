using UnityEngine;

public class BonusController : MonoBehaviour
{
    private Animator animator;
    private ParticleSystem particles;
    PlayerControls playerControls;

    private void Start()
    {
        playerControls = GameObject.Find("Player").GetComponent<PlayerControls>();
        animator = GetComponent<Animator>();
        particles = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            animator.SetTrigger("Play");
            switch (gameObject.tag)
            {
                case "SpeedBonus":
                    playerControls.playerSpeed *= 1.25f;
                    break;
            }
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void StartParticles()
    {
        particles.Play();
    }
}
