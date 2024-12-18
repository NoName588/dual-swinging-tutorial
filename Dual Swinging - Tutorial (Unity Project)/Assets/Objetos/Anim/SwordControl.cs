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
        // Verifica si se ha presionado el bot�n de la rueda del rat�n
        if (Input.GetMouseButtonDown(2) && IsAttack)
        {
            Attacking();
        }
    }

    public void Attacking()
    {
        IsAttack = false;

        // Verifica si el animator est� asignado
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

    // M�todo llamado cuando se detecta una colisi�n

}
