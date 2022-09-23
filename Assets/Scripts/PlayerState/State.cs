using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class State 
{
    protected PlayerController m_playerController;
    protected StateMachine m_stateMachine;
    protected PlayerInput m_playerInput;
    protected PlayerButtons m_playerButtons = PlayerButtons.Instance;

    protected InputAction m_mousePosAction;
    protected InputAction m_movmentAction;
    protected InputAction m_crouchAction;
    protected InputAction m_jumpAction;
    protected InputAction m_runAction;
    protected State (PlayerController playerController, StateMachine stateMachine, PlayerInput playerInput)
    {
        m_playerController = playerController;
        m_stateMachine = stateMachine;
        m_playerInput = playerInput;

        m_movmentAction = playerInput.actions.FindAction(m_playerButtons.WSADButtons);
        m_crouchAction = playerInput.actions.FindAction(m_playerButtons.CrouchButton);
        m_jumpAction = playerInput.actions.FindAction(m_playerButtons.JumpButton);
        m_mousePosAction = playerInput.actions.FindAction(m_playerButtons.MousePosition);
        m_runAction = playerInput.actions.FindAction(m_playerButtons.RunButton);
    }
    public virtual void Enter()
    {

    }

    public virtual void HandleInput()
    {

    }
    public virtual void LogicUpdate()
    {

    }
    public virtual void PhysicsUpdate()
    {

    }
    public virtual void Exit()
    {

    }
}
