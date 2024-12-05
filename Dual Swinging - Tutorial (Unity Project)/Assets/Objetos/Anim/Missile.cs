using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Missile : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionPrefab; // Prefab de la explosi�n
    [SerializeField]
    private float explosionDuration = 3f; // Duraci�n de la explosi�n en segundos

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Body"))
        {
            // Instanciar la explosi�n
            GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);

            // Programar la destrucci�n de la explosi�n despu�s de la duraci�n especificada
            Destroy(explosion, explosionDuration);

            // Destruir el misil
            Destroy(gameObject);

            Debug.Log("BOOOM");
        }
    }
}
