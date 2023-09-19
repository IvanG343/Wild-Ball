using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Material redMat;
    [SerializeField] private Material greenMat;
    [SerializeField] private Material purpleMat;
    [SerializeField] private Material yellowMat;

    [SerializeField] private SceneController sceneController;

    private Renderer playerCurrentMaterial;

    private void Start()
    {
        playerCurrentMaterial = GetComponent<Renderer>();
    }

    public void ChangePlayerColor(string color)
    {
        switch (color)
        {
            case "Yellow":
                playerCurrentMaterial.material = yellowMat;
                gameObject.tag = "Yellow";
                break;
            case "Red":
                playerCurrentMaterial.material = redMat;
                gameObject.tag = "Red";
                break;
            case "Green":
                playerCurrentMaterial.material = greenMat;
                gameObject.tag = "Green";
                break;
            case "Purple":
                playerCurrentMaterial.material = purpleMat;
                gameObject.tag = "Purple";
                break;
            default: break;
        }
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
            Debug.Log("Collision with enemy");
            sceneController.RestartCurrentLevel();
        }
    }

}
