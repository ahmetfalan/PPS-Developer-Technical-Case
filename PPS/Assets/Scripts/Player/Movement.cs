using UnityEngine;

public class Movement : MonoBehaviour
{
    CharacterController characterController;
    Vector2 horizontalInput;

    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] float runSpeed = 8.0f;
    [SerializeField] float jumpForce = 5.0f;

    [SerializeField] float gravityScale = -18.0f;

    Vector3 verticalVelocity = Vector3.zero;

    [SerializeField] LayerMask groundLayer;
    [SerializeField] float distanceToGround = 0.5f;

    [SerializeField] bool isJump;
    [SerializeField] bool isGround;
    [SerializeField] bool isRun;

    private void Awake()
    {
        characterController = this.GetComponent<CharacterController>();
    }

    private void Update()
    {
        isGround = Physics.CheckSphere(transform.position, distanceToGround, groundLayer);
        //if (isGround)
        //    verticalVelocity.y = 0;


        Vector3 horizontalVelocity = (transform.right * horizontalInput.x + transform.forward * horizontalInput.y) * moveSpeed;
        characterController.Move(horizontalVelocity * Time.deltaTime);

        verticalVelocity.y += gravityScale * Time.deltaTime;
        characterController.Move(verticalVelocity * Time.deltaTime);

        if (isJump)
        {
            if (isGround)
            {
                verticalVelocity.y = Mathf.Sqrt(-2f * jumpForce * gravityScale);
            }
            isJump = false;
        }
    }
    public void SetInputs(Vector2 horizontalInput)
    {
        this.horizontalInput = horizontalInput;
    }
    public void OnJumpPressed()
    {
        if (isGround)
        {
            isJump = true;
        }
    }
    public void OnRunPressed()
    {
        isRun = true;
    }
}
