using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Header("Sensibilidad del mouse")]
    public float mouseSensitivity = 100f;

    [Header("Transform del cuerpo del jugador")]
    public Transform playerBody;

    private float xRotation = 0f;

    void Start()
    {
        // Bloquea el cursor al centro de la pantalla y lo oculta
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Obtiene el movimiento del mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Ajusta la rotación en el eje vertical (evita voltear demasiado)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Aplica la rotación vertical a la cámara
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rota el cuerpo del jugador horizontalmente
        playerBody.Rotate(Vector3.up * mouseX);
    }
}

