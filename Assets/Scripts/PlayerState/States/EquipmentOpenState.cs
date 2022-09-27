using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EquipmentOpenState : State
{
    protected bool m_interactButtonPress;
    public EquipmentOpenState(PlayerController playerController, StateMachine stateMachine, PlayerInput playerInput) : base(playerController, stateMachine, playerInput)
    {

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
        m_interactButtonPress = m_interactAction.triggered;

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (m_interactButtonPress)
        {
            if (m_playerController.CurrentInteractObject != null)
            {
                m_playerController.CurrentInteractObject.Interact();
                m_stateMachine.ChangeState(m_stateMachine.PreavoiusState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
