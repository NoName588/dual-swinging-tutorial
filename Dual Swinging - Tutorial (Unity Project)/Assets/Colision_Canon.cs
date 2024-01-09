using UnityEngine;

public class Colision_Canon : MonoBehaviour
{
    // Establece el GameObject espec�fico que representar� la bala de ca��n
    public GameObject balaCanon;

    private void OnCollisionEnter(Collision collision)
    {
        // Comprueba si el objeto con el que colision� es igual al GameObject espec�fico de la bala de ca��n
        if (collision.gameObject == balaCanon)
        {
            // Aqu� puedes poner el c�digo que deseas ejecutar cuando haya una colisi�n con la bala de ca��n
            // Por ejemplo:
            // Destruir la bala de ca��n
            Debug.Log("BOOOOOOOOMMMMMM");

            // Ejecutar otras acciones, instanciar part�culas, etc.
            //Instantiate(HitParticle, new Vector3(collision.transform.position.x, transform.position.y, collision.transform.position.z), collision.transform.rotation);
        }
    }
}
