using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordControl : MonoBehaviour
{
    public Animator swordAnimator;
    public bool IsAttack = true;
    public float Cooldown = 1.0f;

    void Update()
    {
        // Verifica si se ha presionado el botón de la rueda del ratón
        if (Input.GetMouseButtonDown(2))
        {
            Attacking();
        }
    }

    public void Attacking()
    {
        IsAttack = false;

        // Verifica si el animator está asignado
        if (swordAnimator != null)
        {
            swordAnimator.SetTrigger("Attack");
        }

        StartCoroutine(ResestAttack());

        
    }

    IEnumerator ResestAttack()
    {
        yield return new WaitForSeconds(Cooldown);
        IsAttack = true;
    }
}
