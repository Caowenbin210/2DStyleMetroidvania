using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 实体的战斗设置
/// </summary>
public class Entity_Combat : MonoBehaviour
{
    public float damage = 10;

    [Header("目标检测")]
    [SerializeField] private Transform targetCheck; // 击打的目标
    [SerializeField] private float targetCheckRadius = 1; // 打击圆的范围（半径）
    [SerializeField] private LayerMask whatIsTarget; // 击打目标的层

    /// <summary>
    /// 执行攻击
    /// </summary>
    public void PerformAttack()
    {
        foreach(var target in GetDetectedColliders())
        {
            Entity_Health targetHealth = target.GetComponent<Entity_Health>();
            targetHealth?.TakeDamage(damage,transform);
        }
    }

    /// <summary>
    /// 获取检测区域获取到的目标
    /// </summary>
    private Collider2D[] GetDetectedColliders()
    {
        return Physics2D.OverlapCircleAll(targetCheck.position,targetCheckRadius,whatIsTarget);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(targetCheck.position,targetCheckRadius); // 画出检测圆
    }
}
