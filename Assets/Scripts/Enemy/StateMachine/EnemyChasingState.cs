public class EnemyChasingState : EnemyBaseState
{
    public EnemyChasingState(EnemyStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = 1;
        base.Enter();
        StartAnimation(stateMachine.Enemy.AnimationData.GroundParameterHash);
        StartAnimation(stateMachine.Enemy.AnimationData.RunParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Enemy.AnimationData.GroundParameterHash);
        StopAnimation(stateMachine.Enemy.AnimationData.RunParameterHash);
    }

    public override void Update()
    {
        base.Update();

        if (!IsInChaseRange())
        {
            stateMachine.ChangeState(stateMachine.IdleState);
            return;
        }
        else if (IsInAttackRange())
        {
            stateMachine.ChangeState(stateMachine.AttackState);
            return;
        }
        float playerDistanceSqr = (stateMachine.Target.transform.position - stateMachine.Enemy.transform.position).sqrMagnitude;

        // 만약 플레이어가 정지 거리(StoppingDistance) 안쪽에 있다면,
        if (playerDistanceSqr <= stateMachine.Enemy.Data.StoppingDistance * stateMachine.Enemy.Data.StoppingDistance)
        {
            // 이동 속도를 0으로 만들어 제자리에 멈추게 합니다. (하지만 플레이어는 계속 바라봅니다)
            stateMachine.MovementSpeedModifier = 0f;
        }
        else // 플레이어가 정지 거리 밖에 있다면,
        {
            // 다시 최고 속도로 움직입니다.
            stateMachine.MovementSpeedModifier = 1f;
        }

        // base.Update()는 항상 호출하여 회전(Rotate) 로직 등은 계속 실행되게 합니다.
        base.Update();
    }

    protected bool IsInAttackRange()
    {
        float playerDistanceSqr = (stateMachine.Target.transform.position - stateMachine.Enemy.transform.position).sqrMagnitude;

        return playerDistanceSqr <= stateMachine.Enemy.Data.AttackRange * stateMachine.Enemy.Data.AttackRange;
    }
}