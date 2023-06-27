using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float speed = 11f;
    [SerializeField] float gravity = -30f;
    [SerializeField] float jumpHeight = 3.5f;

    Vector2 horizontalInput;
    Vector3 verticalVelocity = Vector3.zero;
    bool jumpPressed;

    public void ReceiveInput(Vector2 input)
    {
        horizontalInput = input;
        Debug.Log(horizontalInput);
    }

    void Update()
    {
        if (isGrounded)
        {
            verticalVelocity.y = 0;

            if (jumpPressed)
            {
                verticalVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                jumpPressed = false;
            }
        }

        Vector3 horizontalVelocity = (transform.right * horizontalInput.x + transform.forward * horizontalInput.y) * speed;
        controller.Move(horizontalVelocity * Time.deltaTime);

        verticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);

    }

    bool isGrounded => Physics.CheckSphere(transform.position, 0.1f, groundMask);

    public void OnJumpPressed() => jumpPressed = true;
}
