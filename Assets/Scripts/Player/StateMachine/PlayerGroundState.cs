using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGroundState : PlayerBaseState
{
    public PlayerGroundState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.GroundParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.GroundParameterHash);
    }

    public override void Update()
    {
        base.Update();
        if (stateMachine.IsAttacking)
        {
            OnAttack();
            stateMachine.IsAttacking = false;
            return;
        }
    }
    protected virtual void OnAttack()
    {
        stateMachine.ChangeState(stateMachine.ComboAttackState);
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (!stateMachine.Player.Controller.isGrounded
            && stateMachine.Player.Controller.velocity.y < Physics.gravity.y * Time.fixedDeltaTime)
        {
            stateMachine.ChangeState(stateMachine.FallState);
            return;
        }
    }
    protected override void OnMovementCanceled(InputAction.CallbackContext context)
    {
        stateMachine.MovementInput = Vector2.zero;

        stateMachine.ChangeState(stateMachine.IdleState);

        //base.OnMovementCanceled(context);
    }

    protected override void OnJumpStarted(InputAction.CallbackContext context)
    {
        base.OnJumpStarted(context);
        stateMachine.ChangeState(stateMachine.JumpState);
    }
}