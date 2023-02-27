using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RigidBodyEntityMovement : BaseGameEntityComponent<BaseGameEntity>, IEntityMovement
{
    public enum MovementMode
    {
        AutoMoveToTarget,
        WSAD,
        Joystick,
        WSADandJoystick,
    }

    [Header("Setting")]
    public MovementMode movementMode;
    public float stoppingDistance = 1f;
    public float speed = 5f;

    [Header("Joystick Setting")]
    //[SerializeField] private FixedJoystick joystick;

    protected MovementState _movementState;

    private Rigidbody2D rb;

    public float StoppingDistance
    {
        get
        {
            return this.stoppingDistance;
        }
    }

    public MovementState MovementState
    {
        get { return _movementState; }
    }

    public float CurrentMoveSpeed
    {
        get { return speed; }
    }

    private Vector2 _lastClickedPos;

    private bool _moving;

    public override void EntityStart()
    {
        base.EntityStart();
        rb = GetComponent<Rigidbody2D>();
    }

    public override void EntityUpdate()
    {
        base.EntityUpdate();

        Movement();
    }

    protected void Movement()
    {
        AutoMoveToTarget();
        KeyMovement();
        PointClickMovement();
    }

    public bool FindGroundedPosition(Vector3 fromPosition, float findDistance, out Vector3 result)
    {
        throw new System.NotImplementedException();
    }

    public Quaternion GetLookRotation()
    {
        throw new System.NotImplementedException();
    }

    public float GetSmoothTurnSpeed()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Auto move to target
    /// </summary>
    protected void AutoMoveToTarget()
    {
        if(movementMode == MovementMode.AutoMoveToTarget && Entity.target != null)
        {
            Vector3 targetPosition = Entity.target.transform.position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
        }
    }

    /// <summary>
    /// Entity Movement by key
    /// </summary>
    public void KeyMovement()
    {
        if(movementMode == MovementMode.WSAD || movementMode == MovementMode.WSADandJoystick)
        {
            Vector3 position = transform.position;

            // get new horizontal position
            float horizontalInput = Input.GetAxis("Horizontal");
            if (horizontalInput > 0)
            {
                position.x += horizontalInput * speed * Time.deltaTime;
                transform.localScale = new Vector2(1f, 1f);
                _movementState = MovementState.Right;
            }
            else if (horizontalInput < 0)
            {
                position.x += horizontalInput * speed * Time.deltaTime;
                transform.localScale = new Vector2(-1f, 1f);
                _movementState = MovementState.Left;
            }

            // get new vertical position
            float verticalInput = Input.GetAxis("Vertical");
            if (verticalInput != 0)
            {
                position.y += verticalInput * speed * Time.deltaTime;
                if (verticalInput >= 0)
                    _movementState = MovementState.Forward;
                else if (verticalInput < 0)
                    _movementState = MovementState.Backward;

            }

            if (horizontalInput == 0 && verticalInput == 0)
            {
                _movementState = MovementState.None;
            }

            // move and clamp in screen
            transform.position = position;
        }
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
        //_rigidbody.velocity = new Vector2(joystick.Horizontal * MoveUnitPerSeconds, joystick.Vertical * MoveUnitPerSeconds);
    }

    public void SetLookRotation(Quaternion rotation)
    {
        throw new System.NotImplementedException();
    }

    public void SetSmoothTurnSpeed(float speed)
    {
        throw new System.NotImplementedException();
    }

    public void StopMove()
    {
        throw new System.NotImplementedException();
    }

    public void Teleport(Vector3 position, Quaternion rotation)
    {
        throw new System.NotImplementedException();
    }
}