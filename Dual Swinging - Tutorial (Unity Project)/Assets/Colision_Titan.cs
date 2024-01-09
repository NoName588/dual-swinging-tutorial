using UnityEngine;

public class Colision_Titan : MonoBehaviour
{
    // public GameObject HitParticle;
    public SwordControl sv;
    // Establece el GameObject específico que representará el cuerpo
    public GameObject cuerpoObjeto;

    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si el objeto con el que colisionó es igual al GameObject específico
        if (other.gameObject == cuerpoObjeto)
        {
            // Verifica si la variable SwordA es verdadera
            if (sv != null && sv.SwordA)
            {
                Debug.Log("Sword attack");

                // O puedes poner directamente el código aquí
                //Instantiate(HitParticle, new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), other.transform.rotation);
            }
        }
    }
}
