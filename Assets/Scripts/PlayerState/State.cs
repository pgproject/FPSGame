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
    protected State (PlayerController playerController, StateMachine stateMachine, PlayerInput playerInput)
    {
        m_playerController = playerController;
        m_stateMachine = stateMachine;
        m_playerInput = playerInput;
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
