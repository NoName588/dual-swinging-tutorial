using UnityEngine;

public class TurretControl : MonoBehaviour
{
    [Header("Objetos de la torreta")]
    public Transform baseObject;   // La base que rota horizontalmente
    public Transform cannonObject; // El cañón que se eleva/desciente

    [Header("Opciones de movimiento")]
    public float baseRotationSpeed = 50f; // Velocidad de rotación de la base
    public float cannonElevationSpeed = 30f; // Velocidad de elevación del cañón
    public float minElevationAngle = -10f; // Ángulo mínimo de elevación
    public float maxElevationAngle = 45f;  // Ángulo máximo de elevación

    void Update()
    {
        HandleBaseRotation();
        HandleCannonElevation();
    }

    void HandleBaseRotation()
    {
        // Detectar entrada horizontal (A y D)
        float horizontalInput = Input.GetAxis("Horizontal"); // -1 (A), 1 (D)
        if (horizontalInput != 0)
        {
            // Rotar la base alrededor del eje Y
            baseObject.Rotate(Vector3.up, horizontalInput * -baseRotationSpeed * Time.deltaTime);
        }
    }

    void HandleCannonElevation()
    {
        // Detectar entrada vertical (W y S)
        float verticalInput = Input.GetAxis("Vertical"); // 1 (W), -1 (S)
        if (verticalInput != 0)
        {
            // Obtener la rotación actual del cañón
            Vector3 currentRotation = cannonObject.localEulerAngles;

            // Convertir el ángulo en un rango continuo (-180 a 180) para clamping
            float currentX = currentRotation.x > 180f ? currentRotation.x - 360f : currentRotation.x;

            // Ajustar el ángulo en el eje X según la entrada y clámparlo
            float newX = Mathf.Clamp(currentX - (verticalInput * cannonElevationSpeed * Time.deltaTime), minElevationAngle, maxElevationAngle);

            // Aplicar la nueva rotación
            cannonObject.localEulerAngles = new Vector3(newX, currentRotation.y, currentRotation.z);
        }
    }
}
