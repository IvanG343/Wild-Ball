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

    private void Awake()
    {
        playerCurrentMaterial = GetComponent<Renderer>();
        playerControls = GetComponent<PlayerControls>();
        fullScreenMap = GameObject.Find("FullScreenMap");
        sceneController = GameObject.Find("LevelLoader").GetComponent<SceneController>();
    }

    //Вызывается из скрипта PowerKeyController
    //Меняет материал игрока на цвет соовтествуюещй сфере
    //Запускает систему частиц для эффекта активации
    //Задаёт игроку тег соовтествующий новому цвету
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

    //Задаёт позицию системе частиц смерти равную позиции игрока
    //Вызывает карту при нажатии на клавишу М
    private void Update()
    {
        deathParticles.transform.position = gameObject.transform.position;

        if(Input.GetKeyDown(KeyCode.M))
            if(!fullScreenMap.activeSelf)
                fullScreenMap.SetActive(true);
            else
                fullScreenMap.SetActive(false);
    }

    //Проверка входа в триггер финиш и смертельная зона
    private void OnTriggerEnter(Collider other)
    {
        //Если игрок зашёл в триггер "финиш" вызываем метод LoadNextLevel из скрипта sceneController для загрузки след. уровня
        if (other.CompareTag("Finish"))
        {
            sceneController.LoadNextLevel();
        }

        //Если игрок зашёл в триггер "смертельная зона" вызываем метод RestartCurrentLevel из скрипта sceneController для перезапуска текующего уровня
        if (other.CompareTag("DeathZone"))
        {
            sceneController.RestartCurrentLevel();
        }
    }

    //Если столкнулись с объектом с тегом Enemy
    //Отключаем управление
    //Отключаем отображение рендера игрок
    //Задаём системе частиц материал соответствующий материалу игрока перед смертью
    //Запускаем систему частиц для анимации эффекта смерти
    //Вызываем метод RestartCurrentLevel из скрипта sceneController для перезапуска текующего уровня
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
