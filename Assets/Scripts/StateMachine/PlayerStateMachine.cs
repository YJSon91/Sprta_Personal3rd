using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public Player Player { get; }

    // 사용하게 될 동작 상태 클래스를 StateMachine에 추가해준다.
    public PlayerIdleState IdleState { get; }

    public Vector2 MovementInput { get; set; }
    public float MovementSpeed { get; private set; }
    public float RotationDamping { get; private set; }
    public float MovementSpeedModifier { get; set; } = 1f;

    public float JumpForce { get; set; }

    public Transform MainCameraTransform { get; set; }

    public PlayerStateMachine(Player player)
    {
        this.Player = player;

        // 미리 로직이 담긴 Class 를 인스턴스화 시킨 다음
        // currentState 변수에 할당 & 해제를 반복해서 사용한다
        // 예) stateMachine.ChangeState(IdleState) 
        // → StateMachine 클래스의 ChangeState 함수 확인
        IdleState = new PlayerIdleState(this);

        MainCameraTransform = Camera.main.transform;

        MovementSpeed = player.Data.GroundData.BaseSpeed;
        RotationDamping = player.Data.GroundData.BaseRotationDamping;
    }
}