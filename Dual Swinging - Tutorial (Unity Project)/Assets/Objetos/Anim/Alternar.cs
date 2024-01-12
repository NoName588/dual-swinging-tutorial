using UnityEngine;

public class Alternar : MonoBehaviour
{
    public GameObject objetoActivo;
    public GameObject objetoInactivo;

    void Update()
    {
        // Obtener el input de desplazamiento del mouse
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        // Alternar entre objetos activados y desactivados
        if (scroll > 0f)
        {
            AlternarObjetosActivos();
        }
        else if (scroll < 0f)
        {
            AlternarObjetosActivos();
        }
    }

    void AlternarObjetosActivos()
    {
        // Alternar la activación/desactivación de los objetos
        objetoActivo.SetActive(!objetoActivo.activeSelf);
        objetoInactivo.SetActive(!objetoInactivo.activeSelf);
    }
}
