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
    [SerializeField]
    public GameObject Explotion;
    [SerializeField]
    private float explosionDuration = 3f; // Duración de la explosión en segundos

    private int mouseButtonClickCount = 0;

    [SerializeField]
    private GameObject smokeTrailPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Body"))
        {
            // Instanciar la explosión
            GameObject explosion = Instantiate(Explotion, transform.position, transform.rotation);

            // Programar la destrucción de la explosión después de la duración especificada
            Destroy(explosion, explosionDuration);

            // Destruir el misil
            Destroy(gameObject);
        }
    }

    private void OnMissileFired()
    {
        if (isActiveAndEnabled)
        {
            GameObject smokeTrail = Instantiate(smokeTrailPrefab, transform.position, Quaternion.identity);
            mouseButtonClickCount++;
            FireMissile();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            mouseButtonClickCount++;
            FireMissile();
        }
    }

    private void FireMissile()
    {
        GameObject missile = Instantiate(missilePrefab, transform.position, transform.rotation);
        Rigidbody missileRb = missile.GetComponent<Rigidbody>();
        missileRb.AddForce(transform.forward * launchSpeed, ForceMode.Impulse);
    }
}