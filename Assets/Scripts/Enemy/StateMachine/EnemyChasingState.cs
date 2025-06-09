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

        // ���� �÷��̾ ���� �Ÿ�(StoppingDistance) ���ʿ� �ִٸ�,
        if (playerDistanceSqr <= stateMachine.Enemy.Data.StoppingDistance * stateMachine.Enemy.Data.StoppingDistance)
        {
            // �̵� �ӵ��� 0���� ����� ���ڸ��� ���߰� �մϴ�. (������ �÷��̾�� ��� �ٶ󺾴ϴ�)
            stateMachine.MovementSpeedModifier = 0f;
        }
        else // �÷��̾ ���� �Ÿ� �ۿ� �ִٸ�,
        {
            // �ٽ� �ְ� �ӵ��� �����Դϴ�.
            stateMachine.MovementSpeedModifier = 1f;
        }

        // base.Update()�� �׻� ȣ���Ͽ� ȸ��(Rotate) ���� ���� ��� ����ǰ� �մϴ�.
        base.Update();
    }

    protected bool IsInAttackRange()
    {
        float playerDistanceSqr = (stateMachine.Target.transform.position - stateMachine.Enemy.transform.position).sqrMagnitude;

        return playerDistanceSqr <= stateMachine.Enemy.Data.AttackRange * stateMachine.Enemy.Data.AttackRange;
    }
}