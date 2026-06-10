using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 实体的健康设置
/// </summary>
public class Entity_Health : MonoBehaviour
{
    private Entity_VFX entityVfx; // 受击特效
    private Entity entity;

    [SerializeField] protected float currentHp;
    [SerializeField] protected float maxHp = 100;
    [SerializeField] protected bool isDead;

    [Header("伤害击退")]
    [SerializeField] private Vector2 knockbackPower = new Vector2(1.5f,2.5f);
    [SerializeField] private Vector2 heavyKnockbackpower = new Vector2(7,7);
    [SerializeField] private float knockbackDuration = .2f;
    [SerializeField] private float heavyKnockbackDuration = .5f;
    [Header("重伤害")]
    [SerializeField] private float heavyDamageThreshold = .3f; // 这将是应该损失的百分比生命值，将其视为重创

    protected virtual void Awake()
    {
        entityVfx = GetComponent<Entity_VFX>();
        entity = GetComponent<Entity>();

        currentHp = maxHp;
    }
    /// <summary>
    /// 调用受击
    /// </summary>
    /// <param name="damage">造成的伤害</param>
    /// <param name="damageDealer">造成伤害的目标</param>
    public virtual void TakeDamage(float damage,Transform damageDealer)
    {
        if(isDead) return;

        Vector2 knockback = CalculateKnockback(damage,damageDealer);
        float duration = CalculateDuration(damage);

        entity?.ReciveKnockback(knockback, duration);
        entityVfx?.PlayOnDamageVfx();
        ReduceHp(damage);
    }

    protected void ReduceHp(float damage)
    {
        currentHp -= damage;

        if (currentHp <= 0)
            Die();
    }

    private void Die()
    {
        isDead = true;
        entity.EntityDeath();
    }
    /// <summary>
    /// 通过伤害值判断是轻击还是重击
    /// </summary>
    /// <param name="damage"></param>
    /// <param name="damageDealer"></param>
    /// <returns></returns>
    private Vector2 CalculateKnockback(float damage, Transform damageDealer)
    {
        int direction = transform.position.x > damageDealer.position.x ? 1 : -1; // 判断造成伤害者在受伤者的左右

        Vector2 knockback = IsHeavyDamage(damage) ? heavyKnockbackpower : knockbackPower;
        knockback.x = knockback.x * direction;

        return knockback;
    }

    private float CalculateDuration(float damage) => IsHeavyDamage(damage) ? heavyKnockbackDuration : knockbackDuration; // 重击返回重击击退时间

    private bool IsHeavyDamage(float damage) => damage / maxHp > heavyDamageThreshold; // 重击返回true
}
