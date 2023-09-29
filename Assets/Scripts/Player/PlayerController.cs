using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Material redMat;
    [SerializeField] private Material greenMat;
    [SerializeField] private Material purpleMat;
    [SerializeField] private Material yellowMat;

    [SerializeField] private ParticleSystem electricityParticles;
    [SerializeField] private ParticleSystem deathParticles;
    [SerializeField] private ParticleSystemRenderer deathParticlesMat;

    private SceneController sceneController;
    private GameObject fullScreenMap;

    private Renderer playerCurrentMaterial;
    private PlayerControls playerControls;
    private AudioSource changeColorSound;

    private void Awake()
    {
        playerCurrentMaterial = GetComponent<Renderer>();
        playerControls = GetComponent<PlayerControls>();
        fullScreenMap = GameObject.Find("FullScreenMap");
        sceneController = GameObject.Find("LevelLoader").GetComponent<SceneController>();
        changeColorSound = GetComponent<AudioSource>();
    }

    //���������� �� ������� PowerKeyController
    //������ �������� ������ �� ���� �������������� �����
    //����� ������ ��� �������������� ������ �����
    //��������� ������� ������ ��� ������� ���������
    //����������� �������� ������ ����� �����
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
        electricityParticles.Play();
        changeColorSound.Play();
    }

    //����� ������� ������� ������ ������ ������ ������� ������
    //�������� ����� ��� ������� �� ������� �
    private void Update()
    {
        deathParticles.transform.position = gameObject.transform.position;

        if(Input.GetKeyDown(KeyCode.M))
            if(!fullScreenMap.activeSelf)
                fullScreenMap.SetActive(true);
            else
                fullScreenMap.SetActive(false);
    }

    //�������� ����� � ������� ����� � ����������� ����
    private void OnTriggerEnter(Collider other)
    {
        //���� ����� ����� � ������� "�����" �������� ����� LoadNextLevel �� ������� sceneController ��� �������� ����. ������
        if (other.CompareTag("Finish"))
        {
            sceneController.LoadNextLevel();
        }

        //���� ����� ����� � ������� "����������� ����" �������� ����� RestartCurrentLevel �� ������� sceneController ��� ����������� ��������� ������
        if (other.CompareTag("DeathZone"))
        {
            sceneController.RestartCurrentLevel();
        }
    }

    //���� ����������� � �������� � ����� Enemy
    //��������� ����������
    //��������� ����������� ������� �����
    //����� ������� ������ �������� ��������������� ��������� ������ ����� �������
    //��������� ������� ������ ��� �������� ������� ������
    //�������� ����� RestartCurrentLevel �� ������� sceneController ��� ����������� ��������� ������
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
