using UnityEngine;

public class Caballo : MonoBehaviour
{
    public Transform jugadorTransform;
    public Transform caballoTransform;
    public Transform camaraCaballo;
    public float velocidadCaminarNormal = 7f;  // Velocidad de caminar predeterminada.
    private float velocidadCaminarMontandoCaballo = 24f;  // Velocidad de caminar al montar el caballo.

    private bool montadoEnCaballo = false;
    private PlayerMovementDualSwinging playerMovementScript;

    void Start()
    {
        // Obtener referencia al script PlayerMovementDualSwinging.
        playerMovementScript = jugadorTransform.GetComponent<PlayerMovementDualSwinging>();

        if (playerMovementScript == null)
        {
            Debug.LogError("PlayerMovementDualSwinging script no encontrado en el jugador.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!montadoEnCaballo && other.CompareTag("Caballo"))
        {
            // Cambiar el estado de montado.
            montadoEnCaballo = true;

            // Ajustar la velocidad de caminar al montar el caballo.
            if (playerMovementScript != null)
            {
                playerMovementScript.walkSpeed = velocidadCaminarMontandoCaballo;
            }
        }
    }

    void Update()
    {
        if (montadoEnCaballo)
        {
            // Igualar la posición y copiar la rotación del jugador al caballo.
            caballoTransform.position = jugadorTransform.position;
            caballoTransform.rotation = jugadorTransform.rotation;

            // Orientar el caballo según la rotación de la nueva cámara.
            OrientarCaballoConCamara();
        }

        // Desmontar del caballo al presionar la tecla 'O'.
        if (Input.GetKeyDown(KeyCode.O))
        {
            DesmontarCaballo();
        }
    }

    void OrientarCaballoConCamara()
    {
        if (camaraCaballo != null)
        {
            // Copiar la rotación de la cámara al caballo, manteniendo la rotación en el eje Y.
            caballoTransform.rotation = Quaternion.Euler(0f, camaraCaballo.eulerAngles.y, 0f);
        }
    }

    void DesmontarCaballo()
    {
        // Cambiar el estado de montado y restablecer la velocidad de caminar.
        montadoEnCaballo = false;

        if (playerMovementScript != null)
        {
            playerMovementScript.walkSpeed = velocidadCaminarNormal;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (montadoEnCaballo && other.CompareTag("Caballo"))
        {
            // Desmontar automáticamente al salir del colisionador del caballo.
            DesmontarCaballo();
        }
    }
}
