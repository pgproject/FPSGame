using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.PlayerState.States
{
    public class StandingState : OnGroundState
    {
        public StandingState(PlayerController playerController, StateMachine stateMachine, PlayerInput playerInput) : base(playerController, stateMachine, playerInput)
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
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}