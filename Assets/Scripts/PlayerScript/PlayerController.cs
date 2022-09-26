using Assets.Scripts.PlayerState;
using Assets.Scripts.PlayerState.States;
using Sirenix.OdinInspector;
using System.Collections;
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
    
    private float m_cameraPosOnCrouch;
    private float m_walkSpeed;
    private float m_runSpeed;
    private float m_inAirSpeed;
    private float m_jumpForce;

    private float m_speedHorizontalRotationCamera;
    private float m_speedVerticalRotationCamera;

    private float m_verticalMaxRotationCamera;
    private float m_verticalMinRotationCamera;
    private LayerMask m_groundLayer;

    private Vector3 m_normalColliderCenterBounds;
    private Vector3 m_normalCameraPos;

    private bool m_isGround;
    private float m_normalHeightOfCollider;
    private float m_pitch;
    private float m_yaw;
    private float m_waitTimeToStartMove;
    private bool m_canRotate;

    public bool IsGround => m_isGround;
    public float JumpForce => m_jumpForce;
    public float InAirSpeed => m_inAirSpeed;
    public float WalkSpeed => m_walkSpeed;
    public float RunSpeed => m_runSpeed;
    private void Start()
    {
        MovmentStateMachine = new StateMachine();

        StandingState = new StandingState(this, MovmentStateMachine, m_playerInput);
        CrouchingState = new CrouchingState(this, MovmentStateMachine, m_playerInput);
        JumpingState = new JumpingState(this, MovmentStateMachine, m_playerInput);


        m_normalColliderCenterBounds = m_playerCollider.center;
        m_normalHeightOfCollider = m_playerCollider.height;
        m_normalCameraPos = m_playerCamera.transform.localPosition;

        PlayerMovmentData playerMovmentData = GeneralAccess.Instance.PlayerMovmentData;

        m_walkSpeed = playerMovmentData.WalkSpeed;
        m_runSpeed = playerMovmentData.RunSpeed;
        m_inAirSpeed = playerMovmentData.InAirSpeed;
        m_jumpForce = playerMovmentData.JumpForce;

        m_speedHorizontalRotationCamera = playerMovmentData.SpeedHorizontalRotationCamera;
        m_speedVerticalRotationCamera = playerMovmentData.SpeedVerticalRotationCamera;

        m_verticalMaxRotationCamera = playerMovmentData.VerticalMaxRotationCamera;
        m_verticalMinRotationCamera = playerMovmentData.VerticalMinRotationCamera;

        m_cameraPosOnCrouch = playerMovmentData.CameraPosOnCrouch;
        m_groundLayer = playerMovmentData.GrundLayer;
        m_waitTimeToStartMove = playerMovmentData.WaitTimeToPlayerCanMove;

        MovmentStateMachine.Initialize(StandingState);

        StartCoroutine(WaitToStartMove());
    }

    private IEnumerator WaitToStartMove()
    {
        yield return new WaitForSeconds(m_waitTimeToStartMove);
        m_canRotate = true;
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

    public void Move(Vector2 inputVector, float speed)
    {
        transform.Translate(new Vector3(inputVector.x * speed, 0, inputVector.y * speed) * Time.deltaTime);
    }

    public void CameraRotation(Vector2 mousePos)
    {
        if (!m_canRotate) return;

        m_yaw += m_speedHorizontalRotationCamera * mousePos.x;
        m_pitch -= m_speedVerticalRotationCamera * mousePos.y;

        m_playerCamera.transform.eulerAngles = new Vector3(Mathf.Clamp(m_pitch, m_verticalMinRotationCamera, m_verticalMaxRotationCamera), 0, 0);
        transform.eulerAngles = new Vector3(0, -m_yaw, 0);
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
    public void Jump(float forceJump)
    {
        m_rigidbodyPlayer.AddForce(Vector3.up * forceJump, ForceMode.Impulse);
    }    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == m_groundLayer.value)
        {
            m_rigidbodyPlayer.useGravity = false;
            m_isGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == m_groundLayer.value)
        {
            m_isGround = false;
        }
    }
    public void TurnOnGravity()
    {
        m_rigidbodyPlayer.useGravity = true;
    }
}
