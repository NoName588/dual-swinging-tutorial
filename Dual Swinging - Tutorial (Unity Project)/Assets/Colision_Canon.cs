using UnityEngine;

public class Colision_Canon : MonoBehaviour
{
    public GameObject bullet;

    [SerializeField]
    private GameObject explosionPrefab; // Prefab de la explosión

    [SerializeField]
    private GameObject smokePrefab;

    [SerializeField]
    private float explosionDuration = 3f; // Duración de la explosión en segundos

    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si el objeto con el que colisionó tiene el tag "Body"
        if (other.CompareTag("Body"))
        {
            // Instanciar la explosión
            GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);

            // Programar la destrucción de la explosión después de la duración especificada
            Destroy(explosion, explosionDuration);

            // Destruir el misil
            Destroy(bullet);

            Debug.Log("Explotion");
        }
        // Comprueba si el objeto con el que colisionó tiene el tag "Titan"
        else if (other.CompareTag("Titan"))
        {
            GameObject ricochet = Instantiate(smokePrefab, transform.position, transform.rotation);

            // Programar la destrucción de la explosión después de la duración especificada
            Destroy(ricochet, explosionDuration);

            // Destruir el misil
            Destroy(bullet);

            Debug.Log("Ricochet");
        }
    }
}
