using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Material redMat;
    [SerializeField] private Material greenMat;
    [SerializeField] private Material purpleMat;
    [SerializeField] private Material yellowMat;

    [SerializeField] private SceneController sceneController;

    [SerializeField] private ParticleSystem electricityParticles;
    [SerializeField] private ParticleSystem deathParticles;
    [SerializeField] private ParticleSystemRenderer deathParticlesMat;

    private Renderer playerCurrentMaterial;
    private PlayerControls playerControls;

    private void Awake()
    {
        playerCurrentMaterial = GetComponent<Renderer>();
        playerControls = GetComponent<PlayerControls>();
    }

    public void ChangePlayerColor(string color)
    {
        switch (color)
        {
            case "Yellow":
                playerCurrentMaterial.material = yellowMat;
                electricityParticles.Play();
                gameObject.tag = "Yellow";
                break;
            case "Red":
                playerCurrentMaterial.material = redMat;
                electricityParticles.Play();
                gameObject.tag = "Red";
                break;
            case "Green":
                playerCurrentMaterial.material = greenMat;
                electricityParticles.Play();
                gameObject.tag = "Green";
                break;
            case "Purple":
                playerCurrentMaterial.material = purpleMat;
                electricityParticles.Play();
                gameObject.tag = "Purple";
                break;
            default: break;
        }
    }

    private void Update()
    {
        deathParticles.transform.position = gameObject.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Finish"))
        {
            sceneController.LoadNextLevel();
        }

        if(other.CompareTag("DeathZone"))
        {
            sceneController.RestartCurrentLevel();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            playerControls.OnDisable();
            playerCurrentMaterial.enabled = false;

            deathParticlesMat.material = playerCurrentMaterial.material;
            deathParticles.Play();

            sceneController.RestartCurrentLevel();
        }
    }

}
