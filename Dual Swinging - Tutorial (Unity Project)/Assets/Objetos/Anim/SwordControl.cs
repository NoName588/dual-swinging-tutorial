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
        // Verifica si se ha presionado el bot�n de la rueda del rat�n
        if (Input.GetMouseButtonDown(2))
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
