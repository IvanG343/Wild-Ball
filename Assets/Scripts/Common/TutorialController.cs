using UnityEngine;

public class TutorialController : MonoBehaviour
{
    [SerializeField] private GameObject tip0;
    [SerializeField] private GameObject tip1;
    [SerializeField] private GameObject tip2;
    [SerializeField] private GameObject tip3;
    [SerializeField] private PlayerControls playerControls;

    private int currentTipIndex;
    private GameObject triggerToDeactivate;
    private bool inTriggerArea;

    private void OnTriggerEnter(Collider other)
    {
        inTriggerArea = true;
        if (other.gameObject.layer == 6)
        {
            playerControls.OnDisable();
            switch (gameObject.name)
            {
                case "0.StartTipTrigger":
                    tip0.SetActive(true);
                    currentTipIndex = 0;
                    triggerToDeactivate = gameObject;
                    break;
                case "1.TrapTipTrigger":
                    tip1.SetActive(true);
                    currentTipIndex = 1;
                    triggerToDeactivate = gameObject;
                    break;
                case "2.PowerNodeTipTrigger":
                    tip2.SetActive(true);
                    currentTipIndex = 2;
                    triggerToDeactivate = gameObject;
                    break;
                case "3.PowerKeyTipTrigger":
                    tip3.SetActive(true);
                    currentTipIndex = 3;
                    triggerToDeactivate = gameObject;
                    break;
            }
        }
    }

    private void Update()
    {
        if (inTriggerArea)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                switch (currentTipIndex)
                {
                    case 0:
                        tip0.SetActive(false);
                        triggerToDeactivate.SetActive(false);
                        playerControls.OnEnable();
                        break;
                    case 1:
                        tip1.SetActive(false);
                        triggerToDeactivate.SetActive(false);
                        playerControls.OnEnable();
                        break;
                    case 2:
                        tip2.SetActive(false);
                        triggerToDeactivate.SetActive(false);
                        playerControls.OnEnable();
                        break;
                    case 3:
                        tip3.SetActive(false);
                        triggerToDeactivate.SetActive(false);
                        playerControls.OnEnable();
                        break;
                }
            }
        }
    }
}
