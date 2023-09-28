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

    //���������, ��� ����� ��������� � ���� �������� ��������
    //��� ������� � �������� ����� ChangeNodeColor ��������� ����� ��� ������ ���� �� ������� ����� ������� �������� ����
    //��������� ������� ��������� ���� � ����������� ����
    //������� ����, ��� ����� � ��������, ����� ��������� ��������������, ����� �� �� ��� ������� � �������� ���� � �������� ����������
    //�������� ����� HideActionTip ������� UIController ��� ������� ��������� "������� � ��� ��������������" ����� ���� ��� ����� ������� ������ ���� ��������
    //�������� ����� ExcludeNodeFromCounter ������� GameManager, �������� �������������� ���� �� ��������
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

    //��� ����� � ������� ���������, ��� ���� ������ ������������ ����� ���� ��� ����������� � ������������
    //�������� ����� ShowActionTip ������� UIController ��� ����������� ��������� "������� � ��� ��������������"
    //������ ���� ��� ����� ��������� � ���� ��������
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == other.gameObject.tag)
        {
            uiController.ShowActionTip();
            playerInArea = true;
        }

    }

    //�������� ����� HideActionTip ������� UIController ��� ������� ��������� "������� � ��� ��������������", ���� ����� ����� �� ��������
    //����� ����, ��� ����� ������� ���� ��������
    private void OnTriggerExit(Collider other)
    {
        uiController.HideActionTip();
        playerInArea = false;
    }

    //������ ���� ���� � ���������� �� ������� ��� � ���������
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