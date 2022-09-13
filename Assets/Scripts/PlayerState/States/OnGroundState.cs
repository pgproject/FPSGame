using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

namespace Assets.Scripts.PlayerState
{
    public class OnGroundState : State
    {
        protected float m_speed;
        protected float m_rotationSpeed;

        private bool m_isCrouching;
        private bool m_isJumping;

        private Vector2 m_inputMousePosVector;
        private Vector2 m_inputMovementVector;

        public OnGroundState(PlayerController playerController, StateMachine stateMachine, PlayerInput playerInput) : base (playerController, stateMachine, playerInput)
        {
            
        }

        public override void Enter()
        {
            base.Enter();
            m_inputMovementVector = Vector2.zero;
        }
        
        public override void Exit()
        {
            base.Exit();
        }

        public override void HandleInput()
        {
            base.HandleInput();
            m_inputMovementVector = m_movmentAction.ReadValue<Vector2>();
            m_inputMousePosVector = m_mousePosAction.ReadValue<Vector2>();
            m_isCrouching = m_crouchAction.triggered;
            m_isJumping = m_jumpAction.triggered;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (m_isJumping)
            {
                m_stateMachine.ChangeState(m_playerController.JumpingState);
            }
            if (m_isCrouching)
            {
                m_stateMachine.ChangeState(m_playerController.CrouchingState);
            }
        }
        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            m_playerController.Move(m_inputMovementVector);
            m_playerController.CameraRotation(m_inputMousePosVector);
        }
    }
}