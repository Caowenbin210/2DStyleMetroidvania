using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_JumpState : Player_AiredState
{
    public Player_JumpState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        // 让物体上升，增加y得速度
        player.SetVelocity(rb.velocity.x, player.jumpForce);
    }

    public override void Update()
    {
        base.Update();

        // 如果y得速度下降，角色进入降落状态  stateMachine.currentState != player.jumpAttackState是因为跳跃转跳跃状态同有y<0的时候，exit后和新的enter是处于同一帧的
        if (rb.velocity.y < 0 && stateMachine.currentState != player.jumpAttackState)
            stateMachine.ChangeState(player.fallState);

    }
}
