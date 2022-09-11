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

        protected float m_speed;
        protected float m_rotationSpeed;

        private Vector2 m_inputVector;
        private bool m_isCrouching;
        private bool m_isJumping;

        public OnGroundState(PlayerController playerController, StateMachine stateMachine, PlayerInput playerInput) : base (playerController, stateMachine, playerInput)
        {
            m_movmentAction = playerInput.actions.FindAction(m_playerButtons.WSADButtons);
            m_crouchAction = playerInput.actions.FindAction(m_playerButtons.CrouchButton);
            m_jumpAction = playerInput.actions.FindAction(m_playerButtons.JumpButton);
        }

        public override void Enter()
        {
            base.Enter();
            m_inputVector = Vector2.zero;
        }

        
        public override void Exit()
        {
            base.Exit();
        }

        public override void HandleInput()
        {
            base.HandleInput();

            m_inputVector = m_movmentAction.ReadValue<Vector2>();
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
            m_playerController.Move(m_inputVector);
        }
      
    }
}