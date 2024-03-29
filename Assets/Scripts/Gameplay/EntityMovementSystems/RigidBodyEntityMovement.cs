using System;
using UnityEngine;

public class RigidBodyEntityMovement : BaseGameEntityComponent<BaseGameEntity>, IEntityMovement
{
    public enum MovementMode
    {
        None,
        AutoMoveToTarget,
        WSAD,
        Joystick,
        WSADAndJoystick,
    }

    [Header("Setting")] public MovementMode movementMode;
    public float stoppingDistance = 1f;

    [Header("Joystick Setting")] [SerializeField]
    private FixedJoystick joystick;

    private BaseCharacterEntity characterEntity;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    public float StoppingDistance
    {
        get { return this.stoppingDistance; }
    }

    public MovementState MovementState
    {
        get { return _movementState; }
        set { _movementState = value; }
    }

    public float CurrentMoveSpeed
    {
        get { return Entity.GetMoveSpeed(); }
    }

    private Vector2 _lastClickedPos;

    private bool _moving;
    private MovementState _movementState;

    public override void EntityAwake()
    {
        base.EntityAwake();

        characterEntity = GetComponent<BaseCharacterEntity>();
    }

    public override void EntityStart()
    {
        base.EntityStart();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    public override void EntityUpdate()
    {
        base.EntityUpdate();

        Movement();
    }

    protected void Movement()
    {
        if (GameInstance.instance.state != GameInstance.GameState.StartGame)
        {
            return;
        }

        if (MovementState == MovementState.Dead)
        {
            return;
        }

        AutoMoveToTarget();
        KeyMovement();
        PointClickMovement();
    }

    public bool FindGroundedPosition(Vector3 fromPosition, float findDistance, out Vector3 result)
    {
        throw new NotImplementedException();
    }

    public Quaternion GetLookRotation()
    {
        throw new NotImplementedException();
    }

    public float GetSmoothTurnSpeed()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Auto move to target
    /// </summary>
    protected void AutoMoveToTarget()
    {
        if (movementMode == MovementMode.AutoMoveToTarget && Entity.target != null)
        {
            Vector3 targetPosition = Entity.target.transform.position;
            if (Vector2.Distance(transform.position, targetPosition) > stoppingDistance)
                transform.position = Vector3.MoveTowards(transform.position, targetPosition,
                    Time.deltaTime * CurrentMoveSpeed);
        }
    }

    /// <summary>
    /// Entity Movement by key
    /// </summary>
    public void KeyMovement()
    {
        if (movementMode is not (MovementMode.WSAD or MovementMode.WSADAndJoystick)) return;
        var position = transform.position;

        // get new horizontal position
        var horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            position.x += horizontalInput * CurrentMoveSpeed * Time.deltaTime;
            anim.SetBool("IsRunning", true);
            if (horizontalInput > 0)
            {
                // transform.localScale = new Vector2(1f, 1f);
                characterEntity.FaceRight();
                _movementState = MovementState.Right;
            }
            else if (horizontalInput < 0)
            {
                //transform.localScale = new Vector2(-1f, 1f);
                characterEntity.FaceLeft();
                _movementState = MovementState.Left;
            }
        }

        // get new vertical position
        var verticalInput = Input.GetAxis("Vertical");
        if (verticalInput != 0)
        {
            position.y += verticalInput * CurrentMoveSpeed * Time.deltaTime;
            anim.SetBool("IsRunning", true);
            if (verticalInput > 0)
            {
                _movementState = MovementState.Forward;
            }
            else if (verticalInput < 0)
            {
                _movementState = MovementState.Backward;
            }
        }

        if (horizontalInput == 0 && verticalInput == 0)
        {
            _movementState = MovementState.None;
            anim.SetBool("IsRunning", false);
        }

        // move and clamp in screen
        transform.position = position;
    }

    /// <summary>
    /// Entity Movement by point click
    /// </summary>
    public void PointClickMovement()
    {
        // if (Input.GetMouseButtonDown(0))
        // {
        //     _lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //     _moving = true;
        // }
        //
        // if (_moving && (Vector2)transform.position != _lastClickedPos)
        // {
        //     float step = MoveUnitPerSeconds * Time.deltaTime;
        //     transform.position = Vector2.MoveTowards(transform.position, _lastClickedPos, step);
        //     if (_lastClickedPos.x < transform.position.x)
        //     {
        //         transform.localScale = new Vector2(-1f, 1f);
        //     }
        //     else if (_lastClickedPos.x > transform.position.x)
        //     {
        //         transform.localScale = new Vector2(1f, 1f);
        //     }
        // }
        // else
        // {
        //     _moving = false;
        // }
    }

    public void FixedUpdate()
    {
        if (movementMode is not (MovementMode.Joystick or MovementMode.WSADAndJoystick)) return;
        rb.velocity = new Vector2(joystick.Horizontal * CurrentMoveSpeed, joystick.Vertical * CurrentMoveSpeed);

        var horizontal = joystick.Horizontal;
        var vertical = joystick.Vertical;
        
        if (horizontal != 0)
        {
            Debug.Log("horizontal: " + horizontal);
            anim.SetBool("IsRunning", true);
            if (horizontal > 0)
            {
                characterEntity.FaceRight();
                _movementState = MovementState.Right;
            }
            else if (horizontal < 0)
            {
                characterEntity.FaceLeft();
                _movementState = MovementState.Left;
            }
        }

        if (vertical != 0)
        {
            anim.SetBool("IsRunning", true);
            if (vertical > 0)
            {
                _movementState = MovementState.Forward;
            }
            else if (vertical < 0)
            {
                _movementState = MovementState.Backward;
            }
        }

        if (horizontal == 0 && vertical == 0)
        {
            _movementState = MovementState.None;
            anim.SetBool("IsRunning", false);
        }
    }

    public void SetLookRotation(Quaternion rotation)
    {
        throw new NotImplementedException();
    }

    public void SetSmoothTurnSpeed(float speed)
    {
        throw new NotImplementedException();
    }

    public void StopMove()
    {
        throw new NotImplementedException();
    }

    public void Teleport(Vector3 position, Quaternion rotation)
    {
        throw new NotImplementedException();
    }
}