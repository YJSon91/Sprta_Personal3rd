using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundState
{
    public PlayerIdleState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    // Idle ���¿� ������ ��
    public override void Enter()
    {
        // ������ �ִ� �����̱� ������ Speed�� 0����
        stateMachine.MovementSpeedModifier = 0f;
        base.Enter();
        // Animation ��ȯ
        StartAnimation(stateMachine.Player.AnimationData.IdleParameterHash);
    }

    // Idle ���¿��� �ٸ� ���·� ��ȯ�� ��
    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.IdleParameterHash);
    }

    public override void Update()
    {
        base.Update();
        if (stateMachine.MovementInput != Vector2.zero)
        {
            // PlayerWalkState ���� ���� �� ����!
            stateMachine.ChangeState(stateMachine.WalkState);
            return;
        }
    }
}