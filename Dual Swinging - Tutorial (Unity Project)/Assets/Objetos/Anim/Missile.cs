using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Missile : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionPrefab; // Prefab de la explosión
    [SerializeField]
    private float explosionDuration = 3f; // Duración de la explosión en segundos

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Body"))
        {
            // Instanciar la explosión
            GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);

            // Programar la destrucción de la explosión después de la duración especificada
            Destroy(explosion, explosionDuration);

            // Destruir el misil
            Destroy(gameObject);

            Debug.Log("BOOOM");
        }
    }
}
