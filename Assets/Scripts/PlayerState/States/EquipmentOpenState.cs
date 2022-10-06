using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EquipmentOpenState : State
{
    protected bool m_openInventoryButtonPress;
    public EquipmentOpenState(PlayerController playerController, StateMachine stateMachine, PlayerInput playerInput) : base(playerController, stateMachine, playerInput)
    {

    }

    public override void Enter()
    {
        base.Enter();
        m_playerController.OpenPlayerInventory();
        m_generalAccess.GameManager.SetCursorState(true);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void HandleInput()
    {
        base.HandleInput();
        m_openInventoryButtonPress = m_openInventoryAction.triggered;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (m_openInventoryButtonPress)
        {
            m_playerController.ClosePlayerInventory();
            m_stateMachine.ChangeState(m_stateMachine.PreavoiusState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
