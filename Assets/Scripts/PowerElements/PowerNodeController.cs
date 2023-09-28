using UnityEngine;

public class PowerNodeController : MonoBehaviour
{
    [SerializeField] private Material redMat;
    [SerializeField] private Material greenMat;
    [SerializeField] private Material purpleMat;
    [SerializeField] private Material yellowMat;
    private UIController uiController;
    private GameManager gameManager;

    private bool playerInArea;

    private Renderer nodeMaterial;
    private Animator nodeAnimator;
    private AudioSource nodeUseSound;

    private void Start()
    {
        uiController = GameObject.Find("UICanvas").GetComponent<UIController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        nodeMaterial = transform.Find("Node").GetComponentInChildren<Renderer>();
        nodeAnimator = transform.Find("Node").GetComponent<Animator>();
        nodeUseSound = transform.Find("Node").GetComponent<AudioSource>();
    }

    //Проверяем, что игрок находится в зоне действия триггера
    //При нажатии Е вызываем метод ChangeNodeColor передавая через тег игрока цвет на который нужно сменить материал ноды
    //Запускаем анимцию активации ноды и проигрываем звук
    //Убираем флаг, что игрок в триггере, после успешного взаимодействия, чтобы он не мог спамить Е запуская звук и анимации бесконечно
    //Вызывает метод HideActionTip скрипта UIController для скрытия подсказки "Нажмите Е для взаимодействия" после того как игрок успешно сменил свой материал
    //Вызывает метод ExcludeNodeFromCounter скрипта GameManager, исключая активированную ноду из счётчика
    private void Update()
    {
        if (playerInArea)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ChangeNodeColor(gameObject.tag);
                nodeAnimator.SetTrigger("StartAnimation");
                nodeUseSound.Play();
                playerInArea = false;
                uiController.HideActionTip();
                gameManager.ExcludeNodeFromCounter(gameObject.tag);
            }
        }
    }

    //При входе в триггер проверяем, что цвет игрока соотвествует цвету ноды для возможности её активировать
    //Вызывает метод ShowActionTip скрипта UIController для отображения подсказки "Нажмите Е для взаимодействия"
    //Задает флаг что игрок находится в зоне триггера
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == other.gameObject.tag)
        {
            uiController.ShowActionTip();
            playerInArea = true;
        }

    }

    //Вызывает метод HideActionTip скрипта UIController для скрытия подсказки "Нажмите Е для взаимодействия", если игрок вышел из триггера
    //Задаём флаг, что игрок покинул зону триггера
    private void OnTriggerExit(Collider other)
    {
        uiController.HideActionTip();
        playerInArea = false;
    }

    //Меняем цвет ноды с дефолтного на целевой при её активации
    public void ChangeNodeColor(string color)
    {
        switch (color)
        {
            case "Yellow":
                nodeMaterial.material = yellowMat;
                break;
            case "Red":
                nodeMaterial.material = redMat;
                break;
            case "Green":
                nodeMaterial.material = greenMat;
                break;
            case "Purple":
                nodeMaterial.material = purpleMat;
                break;
            default: break;
        }
    }

}