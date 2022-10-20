using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditorInternal;
using UnityEngine;

public class PlayerMovmentData : PlayerData
{
    [SerializeField, FoldoutGroup("Player Movment")] private float m_walkSpeed;
    public float WalkSpeed => m_walkSpeed;

    [SerializeField, FoldoutGroup("Player Movment")] private float m_runSpeed;
    public float RunSpeed => m_runSpeed;
    
    [SerializeField, FoldoutGroup("Player Movment")] private float m_inAirSpeed;
    public float InAirSpeed => m_inAirSpeed;

    [SerializeField, FoldoutGroup("Player Movment")] private float m_inAirSpeedWhileWalking;
    public float InAirSpeedWhileWalking => m_inAirSpeedWhileWalking;

    [SerializeField, FoldoutGroup("Player Movment")] private float m_inAirSpeedWhileRunning;
    public float InAirSpeedWhileRunning => m_inAirSpeedWhileRunning;

    [SerializeField, FoldoutGroup("Player Movment")] private float m_jumpForce;
    public float JumpForce => m_jumpForce;

    [SerializeField, FoldoutGroup("Camera data")] private float m_speedHorizontalRotationCamera;
    public float SpeedHorizontalRotationCamera => m_speedHorizontalRotationCamera;

    [SerializeField, FoldoutGroup("Camera data")] private float m_speedVerticalRotationCamera;
    public float SpeedVerticalRotationCamera => m_speedVerticalRotationCamera;

    [SerializeField, FoldoutGroup("Camera data")] private float m_verticalMaxRotationCamera;
    public float VerticalMaxRotationCamera => m_verticalMaxRotationCamera;
    
    [SerializeField, FoldoutGroup("Camera data")] private float m_verticalMinRotationCamera;
    public float VerticalMinRotationCamera => m_verticalMinRotationCamera;

    [SerializeField, FoldoutGroup("Ohter data")] private LayerMask m_groundLayer;
    public LayerMask GrundLayer => m_groundLayer;

    [SerializeField, FoldoutGroup("Ohter data")] private float m_cameraPosOnCrouch;
    public float CameraPosOnCrouch => m_cameraPosOnCrouch;
    [SerializeField, FoldoutGroup("Ohter data")] private float m_waitTimeToPlayerCanMove;
    public float WaitTimeToPlayerCanMove => m_waitTimeToPlayerCanMove;

    [SerializeField, FoldoutGroup("Ohter data")] private float m_distanceToInteractObject;
    public float DistanceToInteractObject => m_distanceToInteractObject;

}
