using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Missile : MonoBehaviour
{
    [SerializeField]
    private GameObject missilePrefab;
    [SerializeField]
    private float launchSpeed = 10f;

    private int mouseButtonClickCount = 0;

    [SerializeField]
    private GameObject smokeTrailPrefab;  // Nuevo prefab para el rastro de humo

    private void Awake()
    {
        // No se necesita PlayerController en este caso
    }

    private void OnTriggerEnter(Collider other)
    {
        // Destruir el misil solo si el otro objeto tiene la etiqueta "Body"
        if (other.CompareTag("Body"))
        {
            Destroy(gameObject);
        }
    }

    private void OnMissileFired()
    {
        if (isActiveAndEnabled)
        {
            // Aseg�rate de que el prefab de rastro de humo est� configurado en el editor
            GameObject smokeTrail = Instantiate(smokeTrailPrefab, transform.position, Quaternion.identity);
            Destroy(smokeTrail, 5f);  // Por ejemplo, destruir el rastro de humo despu�s de 5 segundos

            mouseButtonClickCount++;
            FireMissile();
        }
    }

    private void Update()
    {
        // Verificar si se oprime el bot�n de la rueda del rat�n (bot�n central)
        if (Input.GetMouseButtonDown(2))
        {
            mouseButtonClickCount++;
            FireMissile();
        }
    }

    private void FireMissile()
    {
        // Instanciar el misil en la posici�n y rotaci�n del lanzador
        GameObject missile = Instantiate(missilePrefab, transform.position, transform.rotation);

        // Obtener el Rigidbody del misil
        Rigidbody missileRb = missile.GetComponent<Rigidbody>();

        // Aplicar fuerza al misil en la direcci�n hacia adelante del lanzador
        missileRb.AddForce(transform.forward * launchSpeed, ForceMode.Impulse);
    }
}
