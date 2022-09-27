using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using Assets.Scripts.PlayerState.States;

namespace Assets.Scripts.PlayerState
{
    public class OnGroundState : BaseState
    {
        protected float m_speed;
        protected float m_rotationSpeed;

        private bool m_isCrouching;
        private bool m_isJumping;

        public OnGroundState(PlayerController playerController, StateMachine stateMachine, PlayerInput playerInput) : base (playerController, stateMachine, playerInput)
        {
        }

        public override void Enter()
        {
            base.Enter();
            m_movmentSpeed = m_playerMovmentData.WalkSpeed;
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
            if (m_isJumping && m_playerController.IsGround)
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
        }
    }
}