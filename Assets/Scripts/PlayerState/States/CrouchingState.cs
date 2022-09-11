using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.PlayerState.States
{
    public class CrouchingState : OnGroundState
    {
        private bool m_crouchHeld;
        public CrouchingState(PlayerController playerController, StateMachine stateMachine, PlayerInput playerInput) : base(playerController, stateMachine, playerInput)
        {
            m_crouchAction.started += ctx => m_crouchHeld = true;
            m_crouchAction.canceled += ctx => m_crouchHeld = false;
        }

        public override void Enter()
        {
            base.Enter();
            m_playerController.Crouch(true);
        }

        public override void Exit()
        {
            base.Exit();
            m_playerController.Crouch(false);
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (!m_crouchHeld)
            {
                m_stateMachine.ChangeState(m_playerController.StandingState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
       
    }
}