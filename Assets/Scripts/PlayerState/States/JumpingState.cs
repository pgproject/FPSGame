using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.PlayerState.States
{
    public class JumpingState : State
    {
        private float m_jumpButtonHeldTime;
        private bool m_canCountTime;
        private bool m_playerJump;

        public JumpingState(PlayerController playerController, StateMachine stateMachine, PlayerInput playerInput) : base(playerController, stateMachine, playerInput)
        {
            m_jumpAction.started += ctx => m_canCountTime = true;
            m_jumpAction.canceled += ctx => m_canCountTime = false;
        }
        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
            m_jumpButtonHeldTime = 0;

        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (m_canCountTime)
            {
                m_playerJump = true;
                m_jumpButtonHeldTime += Time.deltaTime;
            }
            if (!m_canCountTime && m_playerJump)
            {
                m_jumpButtonHeldTime = Mathf.Clamp(m_jumpButtonHeldTime, 0, 1);
                m_playerController.Jump(m_jumpButtonHeldTime);
                m_playerJump = false;
            }
            if (m_playerController.IsGround && !m_canCountTime)
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