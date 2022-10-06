using Assets.Scripts.PlayerState;
using Assets.Scripts.PlayerState.States;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public StateMachine StateMachine { get; private set; }
    public StandingState StandingState { get; private set; }
    public CrouchingState CrouchingState { get; private set; }
    public JumpingState JumpingState { get; private set; }
    public EquipmentOpenState EquipmentOpenState { get; private set; }
    public InteractionState InteractionState { get; private set; }

    [SerializeField] private PlayerInput m_playerInput;
    [SerializeField] private Rigidbody m_rigidbodyPlayer;
    [SerializeField] private Transform m_playerTransform;
    [SerializeField] private CapsuleCollider m_playerCollider;
    [SerializeField] private Camera m_playerCamera;
    [SerializeField] private UIObject m_playerInventory;
    [SerializeField] private UIObject m_playerEquipment;

    private float m_cameraPosOnCrouch;

    private float m_speedHorizontalRotationCamera;
    private float m_speedVerticalRotationCamera;

    private float m_verticalMaxRotationCamera;
    private float m_verticalMinRotationCamera;
    private int m_groundLayer;
    private float m_distanceToInteractObject;

    private Vector3 m_normalColliderCenterBounds;
    private Vector3 m_normalCameraPos;

    private bool m_isGround = true;
    private float m_normalHeightOfCollider;
    private float m_pitch;
    private float m_yaw;
    private float m_waitTimeToStartMove;
    private bool m_canRotate;
    private RaycastHit m_raycastHit;
    private IInteractableObject m_currentInteractObject;
    public bool IsGround => m_isGround;
    public IInteractableObject CurrentInteractObject => m_currentInteractObject;
    private void Start()
    {
        m_normalColliderCenterBounds = m_playerCollider.center;
        m_normalHeightOfCollider = m_playerCollider.height;
        m_normalCameraPos = m_playerCamera.transform.localPosition;

        PlayerMovmentData playerMovmentData = GeneralAccess.Instance.PlayerMovmentData;
        m_groundLayer = (int)Mathf.Log(playerMovmentData.GrundLayer.value, 2);

        m_speedHorizontalRotationCamera = playerMovmentData.SpeedHorizontalRotationCamera;
        m_speedVerticalRotationCamera = playerMovmentData.SpeedVerticalRotationCamera;

        m_verticalMaxRotationCamera = playerMovmentData.VerticalMaxRotationCamera;
        m_verticalMinRotationCamera = playerMovmentData.VerticalMinRotationCamera;

        m_cameraPosOnCrouch = playerMovmentData.CameraPosOnCrouch;
        m_waitTimeToStartMove = playerMovmentData.WaitTimeToPlayerCanMove;
        m_distanceToInteractObject = playerMovmentData.DistanceToInteractObject;

        StateMachine = new StateMachine();

        StandingState = new StandingState(this, StateMachine, m_playerInput);
        CrouchingState = new CrouchingState(this, StateMachine, m_playerInput);
        JumpingState = new JumpingState(this, StateMachine, m_playerInput);
        EquipmentOpenState = new EquipmentOpenState(this, StateMachine, m_playerInput);
        InteractionState = new InteractionState(this, StateMachine, m_playerInput);

        StateMachine.Initialize(StandingState);

        StartCoroutine(WaitToStartMove());
    }

    private IEnumerator WaitToStartMove()
    {
        yield return new WaitForSeconds(m_waitTimeToStartMove);
        m_canRotate = true;
    }

    private void Update()
    {
        StateMachine.CurremtState.HandleInput();

        StateMachine.CurremtState.LogicUpdate();
    }
    private void FixedUpdate()
    {
        StateMachine.CurremtState.PhysicsUpdate();
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
        transform.eulerAngles = new Vector3(0, m_yaw, 0);
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

    public void CheckObjectFromCameraForward()
    {
        if (Physics.Raycast(m_playerCamera.transform.position, m_playerCamera.transform.forward, out m_raycastHit, m_distanceToInteractObject))
        {
            if (m_raycastHit.collider.GetComponent<IInteractableObject>() != null)
            {
                m_currentInteractObject = m_raycastHit.collider.GetComponent<IInteractableObject>();
            }
        }
        else
        {
            m_currentInteractObject = null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == m_groundLayer)
        {
            m_rigidbodyPlayer.useGravity = false;
            m_isGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == m_groundLayer)
        {
            m_isGround = false;
        }
    }
    public void TurnOnGravity()
    {
        m_rigidbodyPlayer.useGravity = true;
    }
    public void OpenPlayerInventory()
    {
        m_playerInventory.Open();
        m_playerEquipment.Open();
    }
    public void ClosePlayerInventory()
    {
        m_playerInventory.Close();
        m_playerEquipment.Close();
    }
}
