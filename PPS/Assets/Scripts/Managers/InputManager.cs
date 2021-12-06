using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    PlayerControls inputActions;
    PlayerControls.PlayerMovementActions movementActions;
    PlayerControls.CameraControlActions cameraControlActions;

    [SerializeField] Movement movement;
    [SerializeField] CameraLook cameraLook;
    [SerializeField] Weapon weapon;

    Vector2 horizontalInput;
    Vector2 mouseInput;

    [SerializeField] Text projectileCounter;
    private void Awake()
    {
        Instance = this;
        inputActions = new PlayerControls();
        cameraControlActions = inputActions.CameraControl;

        movementActions = inputActions.PlayerMovement;

        movementActions.Movement.performed += context => horizontalInput = context.ReadValue<Vector2>();
        movementActions.Jump.performed += UwU => movement.OnJumpPressed();

        cameraControlActions.MouseX.performed += context => mouseInput.x = context.ReadValue<float>();
        cameraControlActions.MouseY.performed += context => mouseInput.y = context.ReadValue<float>();

        movementActions.Shoot.performed += UwU => weapon.Shoot();
    }

    private void Update()
    {
        movement.SetInputs(horizontalInput);
        cameraLook.SetInputs(mouseInput);

        projectileCounter.text = "Projectile Count: " + Projectile.projectileCount.ToString();
    }

    public void OnEnable()
    {
        inputActions.Enable();
    }
    public void OnDisable()
    {
        inputActions.Disable();
    }
    private void OnDestroy()
    {
        inputActions.Disable();
    }
}
