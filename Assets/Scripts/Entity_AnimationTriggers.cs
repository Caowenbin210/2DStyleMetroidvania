using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity_AnimationTriggers : MonoBehaviour
{
    private Entity entity;
    private Entity_Combat entityCombat;

    private void Awake()
    {
        entity = GetComponentInParent<Entity>();
        entityCombat = GetComponentInParent<Entity_Combat>();
    }

    public void CurrentStateTrigger()
    {
        entity.CurrentStateAnimationTrigger();
    }

    private void AttackTrigger()
    {
        Debug.Log("我检测到目标了");
        entityCombat.PerformAttack();
    }
}
