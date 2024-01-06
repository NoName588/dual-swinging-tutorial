using UnityEngine;

public class CannonElevation : MonoBehaviour
{
    public Transform cannonBarrel;
    public float minElevation = -10f;  // Cambiado a un valor negativo
    public float maxElevation = 80f;
    public float elevationSpeed = 30f;

    public float currentElevation = 0f;

    void Update()
    {
        // Controlar la elevación del cañón con las teclas 1 y 2
        float inputVertical = 0f;

        if (Input.GetKey(KeyCode.Alpha1))
        {
            inputVertical = 1f;
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            inputVertical = -1f;
        }

        float newElevation = Mathf.Clamp(currentElevation + inputVertical * elevationSpeed * Time.deltaTime, minElevation, maxElevation);
        cannonBarrel.localEulerAngles = new Vector3(-newElevation, 0f, 0f); // Invertir la dirección de rotación en el eje X

        // Actualizar la variable de inclinación actual
        currentElevation = newElevation;

       
    }
}
