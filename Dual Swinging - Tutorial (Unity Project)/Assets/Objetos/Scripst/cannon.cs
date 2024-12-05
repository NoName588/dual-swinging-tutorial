using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour
{
    public GameObject Cannonball;
    public Transform cannonbarrell;

    public float force;
    public float reloadTime = 4.0f;  // Tiempo de recarga en segundos
    private bool isReloading = false;
    private float lastFireTime;

    void Start()
    {
        lastFireTime = -reloadTime;  // Configurar el tiempo inicial para permitir el primer disparo
    }

    void Update()
    {
        // Verificar si el cañón puede disparar
        if (Input.GetKeyUp(KeyCode.Q) && !isReloading && Time.time - lastFireTime >= reloadTime)
        {
            // Disparar el cañón
            GameObject bullet = Instantiate(Cannonball, cannonbarrell.position, cannonbarrell.rotation);
            bullet.GetComponent<Rigidbody>().velocity = cannonbarrell.forward * force * Time.deltaTime;

            // Configurar el tiempo del último disparo
            lastFireTime = Time.time;

            // Activar la recarga
            isReloading = true;
            StartCoroutine(ReloadCannon());
        }
    }

    IEnumerator ReloadCannon()
    {
        // Esperar el tiempo de recarga
        yield return new WaitForSeconds(reloadTime);

        // Desactivar la recarga
        isReloading = false;
    }
}
