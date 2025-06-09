using Unity.VisualScripting;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    public Enemy Enemy { get; }

    public Vector2 MovementInput { get; set; }
    public float MovementSpeed { get; private set; }
    public float RotationDamping { get; private set; }
    public float MovementSpeedModifier { get; set; }

   
    public EnemyIdleState IdleState { get; }
    public EnemyChasingState ChasingState { get; }
    public EnemyAttackState AttackState { get; }
    public Character Target { get; private set; }

    public EnemyStateMachine(Enemy enemy)
    {
        this.Enemy = enemy;
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>(); // ���ӿ�����Ʈ ���� ���ߴ°� Ȯ���غ�����

        IdleState = new EnemyIdleState(this);
        ChasingState = new EnemyChasingState(this);
        AttackState = new EnemyAttackState(this);

        MovementSpeed = Enemy.Data.GroundData.BaseSpeed;
        RotationDamping = Enemy.Data.GroundData.BaseRotationDamping;
    }
}