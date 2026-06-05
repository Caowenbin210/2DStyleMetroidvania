using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity_Combat : MonoBehaviour
{
    [Header("Ä¿±ê¼ì²â")]
    [SerializeField] private Transform targetCheck;
    [SerializeField] private float targetCheckRadius = 1;
    [SerializeField] private LayerMask whatIsTarget;

    public void PerformAttack()
    {
        foreach(var target in GetDetectedColliders())
        {
            Debug.Log("¹¥»÷ÁË" + target.name);
        }
    }

    private Collider2D[] GetDetectedColliders()
    {
        return Physics2D.OverlapCircleAll(targetCheck.position,targetCheckRadius,whatIsTarget);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(targetCheck.position,targetCheckRadius);
    }
}
