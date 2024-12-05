using UnityEngine;

public class Colision_Canon : MonoBehaviour
{
    public GameObject bullet;

    [SerializeField]
    private GameObject explosionPrefab; // Prefab de la explosi�n

    [SerializeField]
    private GameObject smokePrefab;

    [SerializeField]
    private float explosionDuration = 3f; // Duraci�n de la explosi�n en segundos

    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si el objeto con el que colision� tiene el tag "Body"
        if (other.CompareTag("Body"))
        {
            // Instanciar la explosi�n
            GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);

            // Programar la destrucci�n de la explosi�n despu�s de la duraci�n especificada
            Destroy(explosion, explosionDuration);

            // Destruir el misil
            Destroy(bullet);

            Debug.Log("Explotion");
        }
        // Comprueba si el objeto con el que colision� tiene el tag "Titan"
        else if (other.CompareTag("Titan"))
        {
            GameObject ricochet = Instantiate(smokePrefab, transform.position, transform.rotation);

            // Programar la destrucci�n de la explosi�n despu�s de la duraci�n especificada
            Destroy(ricochet, explosionDuration);

            // Destruir el misil
            Destroy(bullet);

            Debug.Log("Ricochet");
        }
    }
}
