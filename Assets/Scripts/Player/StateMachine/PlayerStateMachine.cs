using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public Player Player { get; }

    // ����ϰ� �� ���� ���� Ŭ������ StateMachine�� �߰����ش�.
    public PlayerIdleState IdleState { get; }

    public Vector2 MovementInput { get; set; }
    public float MovementSpeed { get; private set; }
    public float RotationDamping { get; private set; }
    public float MovementSpeedModifier { get; set; } = 1f;

    public float JumpForce { get; set; }

    public Transform MainCameraTransform { get; set; }
    public PlayerWalkState WalkState { get; private set; }
    public PlayerRunState RunState { get; private set; }
    public PlayerJumpState JumpState { get; }
    public PlayerFallState FallState { get; }
    public bool IsAttacking { get; set; }
    public int ComboIndex { get; set; }
    public PlayerComboAttackState ComboAttackState { get; }

    


    public PlayerStateMachine(Player player)
    {
        this.Player = player;

        // �̸� ������ ��� Class �� �ν��Ͻ�ȭ ��Ų ����
        // currentState ������ �Ҵ� & ������ �ݺ��ؼ� ����Ѵ�
        // ��) stateMachine.ChangeState(IdleState) 
        // �� StateMachine Ŭ������ ChangeState �Լ� Ȯ��
        IdleState = new PlayerIdleState(this);
        WalkState = new PlayerWalkState(this);
        RunState = new PlayerRunState(this);
        JumpState = new PlayerJumpState(this);
        FallState = new PlayerFallState(this);
        ComboAttackState = new PlayerComboAttackState(this);

        MainCameraTransform = Camera.main.transform;

        MovementSpeed = player.Data.GroundData.BaseSpeed;
        RotationDamping = player.Data.GroundData.BaseRotationDamping;
        //ChangeState(IdleState);
    }
}