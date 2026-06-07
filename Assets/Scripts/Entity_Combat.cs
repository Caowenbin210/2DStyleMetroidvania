using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity_Combat : MonoBehaviour
{
    public float damage = 10;

    [Header("Ä¿±ê¼ì²â")]
    [SerializeField] private Transform targetCheck;
    [SerializeField] private float targetCheckRadius = 1;
    [SerializeField] private LayerMask whatIsTarget;

    public void PerformAttack()
    {
        foreach(var target in GetDetectedColliders())
        {
            Entity_Health targetHealth = target.GetComponent<Entity_Health>();
            targetHealth?.TakeDamage(damage);
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
