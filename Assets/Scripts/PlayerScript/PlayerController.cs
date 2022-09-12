using Assets.Scripts.PlayerState;
using Assets.Scripts.PlayerState.States;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public StateMachine MovmentStateMachine { get; private set; }
    public StandingState StandingState { get; private set; }
    public CrouchingState CrouchingState { get; private set; }
    public JumpingState JumpingState { get; private set; }

    [SerializeField] private PlayerInput m_playerInput;
    [SerializeField] private Rigidbody m_rigidbodyPlayer;
    [SerializeField] private Transform m_playerTransform;
    [SerializeField] private CapsuleCollider m_playerCollider;
    [SerializeField] private Camera m_playerCamera;
    [SerializeField] private float m_cameraPosOnCrouch;

    [Header("Movment speeds of player"), Space(10)]
    [SerializeField] private float m_movmentSpeed;
    [SerializeField] private float m_jumpingSpeed;

    [Header("Speed rotatnion of camera"), Space(10)]
    [SerializeField] private float m_speedHorizontalRotationCamera;
    [SerializeField] private float m_speedVerticalRotationCamera;

    [Header("Clamp camera rotation")]
    [SerializeField] private float m_verticalMaxRotationCamera;
    [SerializeField] private float m_verticalMinRotationCamera;

    private Vector3 m_normalColliderCenterBounds;
    private Vector3 m_normalCameraPos;


    private float m_normalHeightOfCollider;
    [MinValue(30), MaxValue(90)] private float m_pitch;
    private float m_yaw;

    private void Start()
    {
        MovmentStateMachine = new StateMachine();

        StandingState = new StandingState(this, MovmentStateMachine, m_playerInput);
        CrouchingState = new CrouchingState(this, MovmentStateMachine, m_playerInput);
        JumpingState = new JumpingState(this, MovmentStateMachine, m_playerInput);

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

    public void CameraRotation(Vector2 mousePos)
    {
        m_yaw += m_speedHorizontalRotationCamera * mousePos.x;
        m_pitch -= m_speedVerticalRotationCamera * mousePos.y;
        m_playerCamera.transform.eulerAngles = new Vector3(Mathf.Clamp(m_pitch, m_verticalMinRotationCamera, m_verticalMaxRotationCamera), m_yaw, 0);
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
    public void Jump()
    {
        m_rigidbodyPlayer.MovePosition(gameObject.transform.position + Vector3.up * m_jumpingSpeed);
    }    
    private void OnCollisionEnter(Collision collision)
    {
        m_rigidbodyPlayer.useGravity = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        m_rigidbodyPlayer.useGravity = true;
    }
}
