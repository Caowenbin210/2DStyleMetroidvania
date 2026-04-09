using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Skeleton : Enemy
{
    protected override void Awake()
    {
        base.Awake();

        idleState = new Enemy_Idle(this, stateMachine, "idle");
        moveState = new Enemy_MoveState(this, stateMachine, "move");
    }

    protected override void Start()
    {
        base.Start();

        stateMachine.Initialize(idleState);
    }
}
