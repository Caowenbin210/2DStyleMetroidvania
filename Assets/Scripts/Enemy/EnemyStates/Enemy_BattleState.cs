using UnityEngine;

public class Enemy_BattleState : EnemyState
{
    private Transform player;
    private float lastTimeWasInBattle;

    public Enemy_BattleState(Enemy enemy, StateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }


    public override void Enter()
    {
        base.Enter();

        UpdateBattleTimer();

        //player ??= enemy.GetPlayerReference(); // ??= 相当于 if (player == null)

        if (player == null)
            player = enemy.GetPlayerReference();

        if (ShouldRetreat())
        {
            rb.velocity = new Vector2(enemy.retreatVelocity.x * -DirectionToPlayer(), enemy.retreatVelocity.y);
            enemy.HandleFlip(DirectionToPlayer());
        }
    }

    public override void Update()
    {
        base.Update();

        if (enemy.PlayerDetected())
            UpdateBattleTimer();

        if (BattleTimeIsOver())
            stateMachine.ChangeState(enemy.idleState);

        if (WithinAttackRange() && enemy.PlayerDetected())
            stateMachine.ChangeState(enemy.attackState);
        else
            enemy.SetVelocity(enemy.battleMoveSpeed * DirectionToPlayer(), rb.velocity.y);
    }
    /// <summary>
    /// 更新进入战斗状态时间
    /// </summary>
    private void UpdateBattleTimer() => lastTimeWasInBattle = Time.time;
    /// <summary>
    /// 战斗时间结束了
    /// </summary>
    private bool BattleTimeIsOver() => Time.time > lastTimeWasInBattle + enemy.battleTimeDuration;
    /// <summary>
    /// 玩家和敌人的距离小于了设置的敌人攻击距离
    /// </summary>
    private bool WithinAttackRange() => DistanceToPlayer() < enemy.attackDistance;
    /// <summary>
    /// 玩家和敌人之间的距离小于了因该跳开的距离
    /// </summary>
    private bool ShouldRetreat() => DistanceToPlayer() < enemy.minRetreatDistance;
    /// <summary>
    /// 返回敌人和玩家的距离
    /// </summary>
    private float DistanceToPlayer()
    {
        if (player == null)
            return float.MaxValue;

        return Mathf.Abs(player.position.x - enemy.transform.position.x);
    }
    /// <summary>
    /// 判断玩家在敌人左侧还是右侧
    /// </summary>
    /// <returns></returns>
    private int DirectionToPlayer()
    {
        if (player == null)
            return 0;

        return player.position.x > enemy.transform.position.x ? 1 : -1;
    }

}
