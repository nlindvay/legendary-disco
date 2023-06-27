using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] MouseLook mouseLook;
    [SerializeField] Movement movement;
    [SerializeField] Gun gun;

    PlayerControls controls;
    PlayerControls.GroundMovementActions groundMovement;
    Vector2 horizontalInput;
    Vector2 mouseInput;

    private void Awake()
    {
        controls = new PlayerControls();
        groundMovement = controls.GroundMovement;
        groundMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
        groundMovement.Jump.performed += _ => movement.OnJumpPressed();
        groundMovement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        groundMovement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
        groundMovement.Shoot.performed += _ => gun.Shoot();
    }

    // Update is called once per frame
    void Update()
    {
        movement.ReceiveInput(horizontalInput);
        mouseLook.ReceiveInput(mouseInput);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void OnDestroy()
    {
        controls.Disable();
    }
}