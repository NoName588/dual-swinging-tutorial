using UnityEngine;

public class Cohetes : MonoBehaviour
{
    public GameObject misil1;
    public GameObject misil2;
    public float velocidadMisil = 10f;

    private bool misil1Disparado = false;
    private bool juegoIniciado = false;

    void Start()
    {
        // Desactivar los misiles al inicio.
        misil1.SetActive(false);
        misil2.SetActive(false);

        // Marcar el juego como iniciado despu�s de un breve retraso.
        Invoke("IniciarJuego", 1.0f);
    }

    void IniciarJuego()
    {
        juegoIniciado = true;
    }

    void Update()
    {
        // Verificar si el juego ha iniciado y se oprime el bot�n de la rueda del mouse (bot�n central).
        if (juegoIniciado && Input.GetMouseButtonDown(1))
        {
            if (!misil1Disparado)
            {
                DispararMisil(misil1);
                misil1Disparado = true;
            }
            else
            {
                DispararMisil(misil2);
                misil1Disparado = false;
            }
        }
    }

    void DispararMisil(GameObject misil)
    {
        // Coloca aqu� la l�gica para disparar el misil, por ejemplo, activar el GameObject y establecer su posici�n y direcci�n.
        misil.SetActive(true);
        misil.transform.position = transform.position;
        misil.transform.rotation = transform.rotation;
        // Agrega cualquier otra l�gica necesaria para el disparo.
    }

    void FixedUpdate()
    {
        // Mover los misiles hacia adelante si est�n activos.
        MoverMisil(misil1);
        MoverMisil(misil2);
    }

    void MoverMisil(GameObject misil)
    {
        if (misil.activeSelf)
        {
            // Mover el misil hacia adelante en funci�n de la velocidad y el tiempo.
            misil.transform.Translate(Vector3.forward * velocidadMisil * Time.fixedDeltaTime);
        }
    }
}
