using Assets.Scripts.PlayerState;
using Assets.Scripts.PlayerState.States;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public StateMachine MovmentStateMachine;
    public StandingState StandingState;
    public CrouchingState CrouchingState;

    [SerializeField] private PlayerInput m_playerInput;
    [SerializeField] private Rigidbody m_rigidbodyPlayer;
    [SerializeField] private Transform m_playerTransform;
    [SerializeField] private CapsuleCollider m_playerCollider;
    [SerializeField] private Camera m_playerCamera;

    [SerializeField] private float m_movmentSpeed;
    [SerializeField] private float m_gravitySpeed;
    [SerializeField] private float m_cameraPosOnCrouch;

    private Vector3 m_normalColliderCenterBounds;
    private Vector3 m_normalCameraPos;

    private float m_normalHeightOfCollider;

    private void Start()
    {
        MovmentStateMachine = new StateMachine();

        StandingState = new StandingState(this, MovmentStateMachine, m_playerInput);
        CrouchingState = new CrouchingState(this, MovmentStateMachine, m_playerInput);

        MovmentStateMachine.Initialize(StandingState);

        m_normalColliderCenterBounds = m_playerCollider.center;
        m_normalHeightOfCollider = m_playerCollider.height;
        m_normalCameraPos = m_playerCamera.transform.localPosition;
    }

    private void Update()
    {
        MovmentStateMachine.CurremtState.HandleInput();

        MovmentStateMachine.CurremtState.LogicUpdate();
    }
    private void FixedUpdate()
    {
        MovmentStateMachine.CurremtState.PhysicsUpdate();
    }

    public void Move(Vector2 inputVector)
    {
        m_rigidbodyPlayer.MovePosition(m_playerTransform.position + new Vector3(inputVector.x * m_movmentSpeed, 0, inputVector.y * m_movmentSpeed) * Time.deltaTime);
    }

    public void Crouch(bool enterToCrouch)
    {
        if (enterToCrouch)
        {
            m_playerCollider.center = new Vector3(0, -0.5f, 0);
            m_playerCollider.height /= 2;
            m_playerCamera.transform.localPosition -= new Vector3(0, m_cameraPosOnCrouch, 0);
        }
        else
        {
            m_playerCollider.center = m_normalColliderCenterBounds;
            m_playerCollider.height = m_normalHeightOfCollider;
            m_playerCamera.transform.localPosition = m_normalCameraPos;
        }
    }
       

}
