using UnityEngine;

public class MissileFire : MonoBehaviour
{
    [SerializeField]
    private GameObject missilePrefab; // Prefab del misil (modo dinámico)
    [SerializeField]
    private GameObject smokeTrailPrefab; // Prefab del rastro de humo
    [SerializeField]
    private float launchSpeed = 10f; // Velocidad de lanzamiento del misil

    public bool isStaticMode = false; // Modo de disparo: falso para disparo normal, verdadero para misiles estáticos

    [SerializeField]
    private GameObject staticMissile1; // Primer misil estático en la escena
    [SerializeField]
    private GameObject staticMissile2; // Segundo misil estático en la escena

    private bool isFirstStaticMissile = true; // Controla cuál misil estático se dispara

    private int mouseButtonClickCount = 0; // Contador de disparos

    private void Update()
    {
        // Detectar si se presiona el botón central del mouse
        if (Input.GetMouseButtonDown(2))
        {
            mouseButtonClickCount++;

            if (isStaticMode)
            {
                FireStaticMissile();
            }
            else
            {
                FireMissile();
            }
        }
    }

    private void FireMissile()
    {
        // Instanciar el misil
        GameObject missile = Instantiate(missilePrefab, transform.position, transform.rotation);

        // **Desvincular el misil de la cámara**
        missile.transform.SetParent(null);

        // Obtener el Rigidbody del misil y aplicar una fuerza
        Rigidbody missileRb = missile.GetComponent<Rigidbody>();
        missileRb.AddForce(transform.forward * launchSpeed, ForceMode.Impulse);

        // Instanciar el rastro de humo
        if (smokeTrailPrefab != null)
        {
            Instantiate(smokeTrailPrefab, missile.transform.position, Quaternion.identity);
        }
    }

    private void FireStaticMissile()
    {
        // Seleccionar cuál misil estático disparar
        GameObject missileToFire = isFirstStaticMissile ? staticMissile1 : staticMissile2;

        if (missileToFire != null)
        {
            // **Desvincular el misil de la cámara**
            missileToFire.transform.SetParent(null);

            // Obtener el Rigidbody del misil
            Rigidbody missileRb = missileToFire.GetComponent<Rigidbody>();

            if (missileRb != null)
            {
                // Asegurarnos de que no sea kinematic y aplicarle una fuerza
                missileRb.isKinematic = false;
                missileRb.AddForce(transform.forward * launchSpeed, ForceMode.Impulse);

                // Instanciar el rastro de humo
                if (smokeTrailPrefab != null)
                {
                    Instantiate(smokeTrailPrefab, missileToFire.transform.position, Quaternion.identity);
                }
            }
        }

        // Alternar al siguiente misil estático
        isFirstStaticMissile = !isFirstStaticMissile;
    }
}
