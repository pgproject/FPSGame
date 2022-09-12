using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

namespace Assets.Scripts.PlayerState
{
    public class OnGroundState : State
    {
        protected InputAction m_movmentAction;
        protected InputAction m_crouchAction;
        protected InputAction m_jumpAction;
        protected InputAction m_mousePosAction;

        protected float m_speed;
        protected float m_rotationSpeed;

        private bool m_isCrouching;
        private bool m_isJumping;

        private Vector2 m_inputMousePosVector;
        private Vector2 m_inputMovementVector;

        public OnGroundState(PlayerController playerController, StateMachine stateMachine, PlayerInput playerInput) : base (playerController, stateMachine, playerInput)
        {
            m_movmentAction = playerInput.actions.FindAction(m_playerButtons.WSADButtons);
            m_crouchAction = playerInput.actions.FindAction(m_playerButtons.CrouchButton);
            m_jumpAction = playerInput.actions.FindAction(m_playerButtons.JumpButton);
            m_mousePosAction = playerInput.actions.FindAction(m_playerButtons.MousePosition);
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