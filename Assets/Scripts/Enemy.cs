using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public Enemy_Idle idleState;
    public Enemy_MoveState moveState;
    public Enemy_AttackState attackState;
    public Enemy_BattleState battleState;

    [Header("战斗细节")]
    public float battleMoveSpeed = 3;
    public float attackDistance = 2;

    [Header("移动细节")]
    public float idleTime = 2;
    public float moveSpeed = 1.4f;
    [Range(0f, 2f)]
    public float moveAnimSpeedMultiplier = 1;

    [Header("玩家检测")]
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private Transform playerCheck;
    [SerializeField] private float playerCheckDistance = 10;

    public RaycastHit2D PlayerDetection()
    {
        RaycastHit2D hit = Physics2D.Raycast(playerCheck.position, Vector2.right, playerCheckDistance, whatIsPlayer | whatIsGround);

        if(hit.collider == null || hit.collider.gameObject.layer != LayerMask.NameToLayer("Player"))
            return default; 

        return hit;
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(playerCheck.position,new Vector3(playerCheck.position.x + (facingDir * playerCheckDistance),playerCheck.position.y));
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(playerCheck.position,new Vector3(playerCheck.position.x + (facingDir * attackDistance),playerCheck.position.y));
    }
}
