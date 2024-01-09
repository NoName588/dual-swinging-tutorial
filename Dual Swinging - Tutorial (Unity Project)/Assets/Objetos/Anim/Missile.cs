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

    void Update()
    {
        // Verificar si se oprime el botón de la rueda del ratón (botón central)
        if (Input.GetMouseButtonDown(2))
        {
            FireMissile();
        }
    }

    void FireMissile()
    {
        // Instanciar el misil en la posición y rotación del lanzador
        GameObject missile = Instantiate(missilePrefab, transform.position, transform.rotation);

        // Obtener el Rigidbody del misil
        Rigidbody missileRb = missile.GetComponent<Rigidbody>();

        // Aplicar fuerza al misil en la dirección hacia adelante del lanzador
        missileRb.AddForce(transform.forward * launchSpeed, ForceMode.Impulse);
    }
}
