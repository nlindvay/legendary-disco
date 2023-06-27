using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float sensitivityX = 11f;
    [SerializeField] float sensitivityY = 0.1f;
    [SerializeField] Transform playerCamera;
    [SerializeField] float xClamp = 85f;

    float mouseX, mouseY;
    float xRotation = 0f;

    public void ReceiveInput(Vector2 input)
    {
        mouseX = input.x * sensitivityX;
        mouseY = input.y * sensitivityY;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * mouseX * Time.deltaTime);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);
        Vector3 targetRotation = transform.eulerAngles;
        targetRotation.x = xRotation;
        playerCamera.eulerAngles = targetRotation;
    }
}