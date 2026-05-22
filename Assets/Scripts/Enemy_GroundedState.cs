using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_GroundedState : EnemyState
{
    public Enemy_GroundedState(Enemy enemy, StateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Update()
    {
        base.Update();

        // 如果敌人检测到玩家
        // 状态机将切换为战斗状态
        if(enemy.PlayerDetected() == true)
            stateMachine.ChangeState(enemy.battleState);
        
    }
}
