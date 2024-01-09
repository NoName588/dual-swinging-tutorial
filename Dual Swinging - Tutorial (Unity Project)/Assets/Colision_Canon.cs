using UnityEngine;

public class Colision_Canon : MonoBehaviour
{
    // Establece el GameObject específico que representará la bala de cañón
    public GameObject balaCanon;

    private void OnCollisionEnter(Collision collision)
    {
        // Comprueba si el objeto con el que colisionó es igual al GameObject específico de la bala de cañón
        if (collision.gameObject == balaCanon)
        {
            // Aquí puedes poner el código que deseas ejecutar cuando haya una colisión con la bala de cañón
            // Por ejemplo:
            // Destruir la bala de cañón
            Debug.Log("BOOOOOOOOMMMMMM");

            // Ejecutar otras acciones, instanciar partículas, etc.
            //Instantiate(HitParticle, new Vector3(collision.transform.position.x, transform.position.y, collision.transform.position.z), collision.transform.rotation);
        }
    }
}
