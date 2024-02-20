using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBattleState : EnemyState
{
    protected Enemy_Skeleton enemy;
    private int moveDir;
    public SkeletonBattleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Skeleton _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();


        if(enemy.IsplayerDetected())
        {
            stateTimer = enemy.battleTime;
            if(enemy.IsplayerDetected().distance < enemy.attackDistance )
            {
                if(CanAttack())
                stateMachine.ChangeState(enemy.attackState);
            }
        }
        else
        {
            if(stateTimer<0 ||Vector2.Distance(player.transform.position , enemy.transform.position) > 7) 
                stateMachine.ChangeState(enemy.idleState);
        }


        if (player.position.x > enemy.transform.position.x)
            moveDir = 1;
        else if (player.position.x < enemy.transform.position.x)
            moveDir = -1;

        enemy.SetVelocity(enemy.moveSpeed * moveDir, rb.velocity.y);
    }
    private bool CanAttack()
    {
        if(Time.time >= enemy.lastTimeAttacked + enemy.attackCooldown)
        {
            enemy.lastTimeAttacked = Time.time;
            return true;
        }

        return false;
    }
}