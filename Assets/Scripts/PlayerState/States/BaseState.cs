using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.PlayerState.States
{
    public class BaseState : State
    {
        protected Vector2 m_inputMousePosVector;
        protected Vector2 m_inputMovementVector;

        protected float m_movmentSpeed;
        protected float m_inAirSpeed;
        public BaseState(PlayerController playerController, StateMachine stateMachine, PlayerInput playerInput) : base(playerController, stateMachine, playerInput)
        {
            m_runAction.started += ctx => m_movmentSpeed = m_playerController.RunSpeed;
            m_runAction.canceled += ctx => m_movmentSpeed = m_playerController.WalkSpeed;
            m_inAirSpeed = playerController.InAirSpeed;
        }

        public override void Enter()
        {
            base.Enter();
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
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            m_playerController.Move(m_inputMovementVector, m_movmentSpeed);
            m_playerController.CameraRotation(m_inputMousePosVector);
        }
    }
}