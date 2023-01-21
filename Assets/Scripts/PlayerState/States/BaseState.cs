using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        protected bool m_interactButtonPress;
        protected bool m_openInventoryButtonPress;
        protected bool m_aatackButtonPrees;
        public BaseState(PlayerController playerController, StateMachine stateMachine, PlayerInput playerInput) : base(playerController, stateMachine, playerInput)
        {
            m_runAction.started += ctx => m_movmentSpeed = m_playerMovmentData.RunSpeed;
            m_runAction.canceled += ctx => m_movmentSpeed = m_playerMovmentData.WalkSpeed;
            m_inAirSpeed = m_playerMovmentData.InAirSpeed;
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

            m_interactButtonPress = m_interactAction.triggered;
            m_openInventoryButtonPress = m_openInventoryAction.triggered;
            m_aatackButtonPrees = m_baseAttackAction.triggered;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (m_interactButtonPress)
            {
                if (m_playerController.CurrentInteractObject != null)
                {
                    m_generalAccess.GameManager.SetCursorState(true);

                    m_playerController.CurrentInteractObject.Interact();
                    m_stateMachine.ChangeState(m_playerController.InteractionState);
                }
            }
            if (m_openInventoryButtonPress)
            {
                m_stateMachine.ChangeState(m_playerController.EquipmentOpenState);

            }
            if (m_aatackButtonPrees)
            {
                m_playerController.Attack();
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            m_playerController.Move(m_inputMovementVector, m_movmentSpeed);
            m_playerController.CameraRotation(m_inputMousePosVector);
            m_playerController.CheckObjectFromCameraForward();
        }
    }
}