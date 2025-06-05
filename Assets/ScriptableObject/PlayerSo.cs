using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using JetBrains.Annotations;



[Serializable]
public class PlayerGroundData
{
    [field: SerializeField][field: Range(0f,25f)] public float BaseSpeed { get; private set; } = 5f;
    [field: SerializeField][field: Range(0f, 25f)] public float BaseRotationDamping { get; private set; } = 1f;

    [field:Header("IdleData")]
    [field:Header("WalkData")]
    [field: SerializeField][field: Range(0f, 2f)] public float WalkSpeedModifier { get; private set; } = 0.225f;

    [field: Header("RunData")]
    [field: SerializeField][field: Range(0f, 2f)] public float RunSpeedModifier { get; private set; } = 1f;

}

[Serializable]
public class PlayerAirData
{
    //[SerializeField][field: Range(0f, 25f)] public float AirSpeed { get; private set; } = 5f;
    //[SerializeField][field: Range(0f, 25f)] public float AirRotationDamping { get; private set; } = 1f;
    [field: Header("JumpData")]
    [field: SerializeField][field: Range(0f, 25f)] public float JumpForce { get; private set; } = 5f;
    //  [SerializeField][field: Range(0f, 25f)] public float JumpHeight { get; private set; } = 2.5f;
}

[CreateAssetMenu(fileName = "Player" , menuName = "Characters/Player")]
public class PlayerSo : ScriptableObject
{
    [field:SerializeField] public PlayerGroundData GroundData { get; private set; }
    [field: SerializeField] public PlayerAirData AirData { get; private set; }
}


