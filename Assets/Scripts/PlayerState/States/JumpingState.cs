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
        private float m_playerPositionOnYAxis;

        private bool m_canCountTime;
        private bool m_playerRealaseButtonJump;
        private bool m_isGravity;
        public JumpingState(PlayerController playerController, StateMachine stateMachine, PlayerInput playerInput) : base(playerController, stateMachine, playerInput)
        {
            m_jumpAction.started += ctx => m_canCountTime = true;
            m_jumpAction.canceled += ctx => m_canCountTime = false;
            m_jumpAction.canceled += ctx => m_movmentSpeed = m_inAirSpeed;

            m_runAction.started += ctx => m_movmentSpeed = m_playerController.RunSpeed;
            m_runAction.started += ctx => m_inAirSpeed = m_playerController.RunSpeed * 5;

            m_runAction.canceled += ctx => m_movmentSpeed = m_playerController.WalkSpeed;
            m_runAction.canceled += ctx => m_inAirSpeed = m_playerController.WalkSpeed;

            m_movmentAction.started += ctx => m_inAirSpeed = m_playerController.WalkSpeed * 2;
            m_movmentAction.started += ctx => m_movmentSpeed = m_playerController.WalkSpeed;

            m_movmentAction.canceled += ctx => m_inAirSpeed = m_playerController.InAirSpeed;

            m_maxJumpForce = m_playerController.JumpForce;
        }
        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
            m_jumpButtonHeldTime = 0;
            m_realJumpForce = 0;
            m_playerPositionOnYAxis = 0;

            m_isGravity = false;
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

                m_playerPositionOnYAxis = m_playerController.transform.position.y + m_realJumpForce;
                m_playerRealaseButtonJump = true;
                m_playerController.Jump(m_realJumpForce);
            }

            if (m_playerController.IsGround && m_playerRealaseButtonJump)
            {
                m_stateMachine.ChangeState(m_playerController.StandingState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            if (m_playerController.transform.position.y > m_playerPositionOnYAxis && !m_isGravity)
            {
                m_playerController.TurnOnGravity();
                m_isGravity = true;
            }
        }
    }
}