using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : Entity_Health
{
    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    public override void TakeDamage(float damage, Transform damageDealer)
    {
        if (damageDealer.GetComponent<Player>() != null)
            enemy.TryEnterBattleState(damageDealer); // 敌人尝试进入战斗状态

        base.TakeDamage(damage, damageDealer);
    }
}
