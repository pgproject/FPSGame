using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditorInternal;
using UnityEngine;

public class PlayerMovmentData : PlayerData
{
    [SerializeField, BoxGroup("Movment")] private float m_walkSpeed;
    public float WalkSpeed => m_walkSpeed;

    [SerializeField, BoxGroup("Movment")] private float m_runSpeed;
    public float RunSpeed => m_runSpeed;
    
    [SerializeField, BoxGroup("Movment")] private float m_inAirSpeed;
    public float InAirSpeed => m_inAirSpeed;
    
    [VerticalGroup("Camera", PaddingTop = 10)]
    [SerializeField, BoxGroup("Camera/Camera rotation")] private float m_speedHorizontalRotationCamera;
    public float SpeedHorizontalRotationCamera => m_speedHorizontalRotationCamera;

    [SerializeField, BoxGroup("Camera/Camera rotation")] private float m_speedVerticalRotationCamera;
    public float SpeedVerticalRotationCamera => m_speedVerticalRotationCamera;

    [SerializeField, BoxGroup("Camera/Camera rotation")] private float m_verticalMaxRotationCamera;
    public float VerticalMaxRotationCamera => m_verticalMaxRotationCamera;
    
    [SerializeField, BoxGroup("Camera/Camera rotation")] private float m_verticalMinRotationCamera;
    public float VerticalMinRotationCamera => m_verticalMinRotationCamera;

    [Space(10)]
    [SerializeField] private float m_jumpForce;
    public float JumpForce => m_jumpForce;
    
    [SerializeField] private LayerMask m_groundLayer;
    public LayerMask GrundLayer => m_groundLayer;

    [SerializeField] private float m_cameraPosOnCrouch;
    public float CameraPosOnCrouch => m_cameraPosOnCrouch;
    [SerializeField] private float m_waitTimeToPlayerCanMove;
    public float WaitTimeToPlayerCanMove => m_waitTimeToPlayerCanMove;
}
