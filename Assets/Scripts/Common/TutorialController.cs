using UnityEngine;

public class TutorialController : MonoBehaviour
{
    [SerializeField] private GameObject tip0Panel;
    [SerializeField] private GameObject tip1Panel;
    [SerializeField] private GameObject tip2Panel;
    [SerializeField] private GameObject tip3Panel;
    [SerializeField] private GameObject tip4Panel;

    private PlayerControls playerControls;
    private GameObject triggerToDeactivate;
    private int tipIndex;
    private bool inTriggerArea;

    private void Start()
    {
        playerControls = GameObject.Find("Player").GetComponent<PlayerControls>();
    }

    //При входе в триггер проверяем, что вошёл игрок
    //Отключаем управление, проверяем в какой именно триггер вошли
    //Активируем панель с текстом, задаём ID текущей подсказки, чтобы далее её отключить
    //Присваиваем текущий тригер в перменную triggerToDeactivate для дальнейшней деактивации
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            inTriggerArea = true;
            playerControls.OnDisable();
            switch (gameObject.name)
            {
                case "Tip0Trigger":
                    tip0Panel.SetActive(true);
                    tipIndex = 0;
                    triggerToDeactivate = gameObject;
                    break;
                case "Tip1Trigger":
                    tip1Panel.SetActive(true);
                    triggerToDeactivate = gameObject;
                    tipIndex = 1;
                    break;
                case "Tip2Trigger":
                    tip2Panel.SetActive(true);
                    triggerToDeactivate = gameObject;
                    tipIndex = 2;
                    break;
                case "Tip3Trigger":
                    tip3Panel.SetActive(true);
                    triggerToDeactivate = gameObject;
                    tipIndex = 3;
                    break;
                case "Tip4Trigger":
                    tip4Panel.SetActive(true);
                    triggerToDeactivate = gameObject;
                    tipIndex = 4;
                    break;
            }
        }
    }

    //При нажатии E отключаем подсказу по её индексу
    //Отключаем триггер, чтобы не сработал повторно
    //Возвращаем управление игроку
    private void Update()
    {
        if (inTriggerArea && Input.GetKeyDown(KeyCode.E))
        {
            switch (tipIndex)
            {
                case 0:
                    tip0Panel.SetActive(false);
                    break;
                case 1:
                    tip1Panel.SetActive(false);
                    break;
                case 2:
                    tip2Panel.SetActive(false);
                    break;
                case 3:
                    tip3Panel.SetActive(false);
                    break;
                case 4:
                    tip4Panel.SetActive(false);
                    break;
            }
            triggerToDeactivate.SetActive(false);
            playerControls.OnEnable();
        }
    }
}
