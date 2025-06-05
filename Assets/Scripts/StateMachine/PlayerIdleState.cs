using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundState
{
    public PlayerIdleState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    // Idle 상태에 들어왔을 때
    public override void Enter()
    {
        // 가만히 있는 상태이기 때문에 Speed를 0으로
        stateMachine.MovementSpeedModifier = 0f;
        base.Enter();
        // Animation 전환
        StartAnimation(stateMachine.Player.AnimationData.IdleParameterHash);
    }

    // Idle 상태에서 다른 상태로 전환될 때
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
            // PlayerWalkState 먼저 생성 후 복귀!
            stateMachine.ChangeState(stateMachine.WalkState);
            return;
        }
    }
}