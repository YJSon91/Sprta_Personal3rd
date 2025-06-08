public class PlayerJumpState : PlayerAirState
{
    public PlayerJumpState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.JumpForce = stateMachine.Player.Data.AirData.JumpForce;
        stateMachine.Player.ForceReceiver.Jump(stateMachine.JumpForce);
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.JumpParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.JumpParameterHash);
    }

    public override void Update()
    {
        base.Update();

        // Jump ���¿��� ForceReceiver�� ���� �߶��ϰ� ���� ��
        // velocity(��ȭ��)�� ������ �Ǵ� ������ �̿�
        if (stateMachine.Player.Controller.velocity.y <= 0)
        {
            // Idle ���·� ��ȯ �� ���� Fall ���·� ��ȯ ����
            stateMachine.ChangeState(stateMachine.FallState);
            return;
        }
    }
}
