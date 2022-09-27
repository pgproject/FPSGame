using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.PlayerState.States
{
    public class JumpingState : BaseState
    {
        private float m_jumpButtonHeldTime;
        private float m_maxJumpForce;
        private float m_realJumpForce;

        private bool m_canCountTime;
        private bool m_playerRealaseButtonJump;

        private bool m_playerAfterJump;
        public JumpingState(PlayerController playerController, StateMachine stateMachine, PlayerInput playerInput) : base(playerController, stateMachine, playerInput)
        {

            m_jumpAction.started += ctx => m_canCountTime = true;
            m_jumpAction.canceled += ctx => m_canCountTime = false;
            m_jumpAction.canceled += ctx => m_movmentSpeed = m_inAirSpeed;

            m_runAction.started += ctx => m_movmentSpeed = m_playerMovmentData.RunSpeed;
            m_runAction.started += ctx => m_inAirSpeed = m_playerMovmentData.RunSpeed * m_playerMovmentData.InAirSpeedWhileRunning;

            m_runAction.canceled += ctx => m_movmentSpeed = m_playerMovmentData.WalkSpeed;
            m_runAction.canceled += ctx => m_inAirSpeed = m_playerMovmentData.WalkSpeed;

            m_movmentAction.started += ctx => m_inAirSpeed = m_playerMovmentData.WalkSpeed * m_playerMovmentData.InAirSpeedWhileWalking;
            m_movmentAction.started += ctx => m_movmentSpeed = m_playerMovmentData.WalkSpeed;

            m_movmentAction.canceled += ctx => m_inAirSpeed = m_playerMovmentData.InAirSpeed;

            m_maxJumpForce = m_playerMovmentData.JumpForce;
        }
        public override void Enter()
        {
            base.Enter();
            m_playerController.TurnOnGravity();
        }

        public override void Exit()
        {
            base.Exit();

            m_jumpButtonHeldTime = 0;
            m_realJumpForce = 0;
            m_playerAfterJump = false;
            m_playerRealaseButtonJump = false;
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
                m_jumpButtonHeldTime += Time.deltaTime;
            }
            if (!m_canCountTime && !m_playerRealaseButtonJump)
            {
                m_jumpButtonHeldTime = Mathf.Clamp(m_jumpButtonHeldTime, 0, 1);
                m_realJumpForce = m_jumpButtonHeldTime * m_maxJumpForce;

                m_playerRealaseButtonJump = true;
            }

            if (m_playerController.IsGround && m_playerAfterJump)
            {
                m_stateMachine.ChangeState(m_playerController.StandingState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            if (m_playerRealaseButtonJump)
            {
                m_playerController.Jump(m_realJumpForce);
                m_playerAfterJump = true;
            }
        }
    }
}