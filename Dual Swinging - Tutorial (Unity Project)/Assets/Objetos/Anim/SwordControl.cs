using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordControl : MonoBehaviour
{
    public Animator swordAnimator;
    public bool IsAttack = true;
    public float Cooldown = 1.0f;
    public bool SwordA = false;

    void Update()
    {
        // Verifica si se ha presionado el botón de la rueda del ratón
        if (Input.GetMouseButtonDown(2) && IsAttack)
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
            SwordA = true;
            swordAnimator.SetTrigger("Attack");
        }

        StartCoroutine(ResetAttack());
    }

    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(Cooldown);
        IsAttack = true;
        SwordA=false;
    }

    // Método llamado cuando se detecta una colisión

}
