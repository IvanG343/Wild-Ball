using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2.0f;

    [SerializeField] private Transform cameraTransform;
    private Vector3 offset;

    private Rigidbody playerRB;
    private Vector3 movement;
    public bool isGrounded = true;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        offset = cameraTransform.position - transform.position;
    }

    private void OnCollisionEnter()
    {
        isGrounded = true;
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movement = new Vector3(horizontal, 0, vertical).normalized;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            CharacterJump();
    }

    private void FixedUpdate()
    {
        CharacterMove(movement);
        cameraTransform.position = transform.position + offset;
    }

    public void CharacterMove(Vector3 movement)
    {
        playerRB.AddForce(movement * speed);
    }

    public void CharacterJump()
    {
        isGrounded = false;
        playerRB.AddForce(new Vector3(0f, 200f, 0f));
    }
}
