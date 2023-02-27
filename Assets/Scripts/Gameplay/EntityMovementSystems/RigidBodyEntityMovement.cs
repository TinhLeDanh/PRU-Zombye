using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RigidBodyEntityMovement : BaseGameEntityComponent<BaseGameEntity>, IEntityMovement
{
    public float StoppingDistance => throw new System.NotImplementedException();

    public MovementState MovementState
    {
        get { return movementState; }
    }

    public Vector2 Direction
    {
        get => throw new System.NotImplementedException();
        set => throw new System.NotImplementedException();
    }

    public float CurrentMoveSpeed => throw new System.NotImplementedException();

    private const float MoveUnitPerSeconds = 5f;

    private Vector2 _lastClickedPos;

    private bool _moving;

    //[SerializeField] private FixedJoystick joystick;
    private Rigidbody2D _rigidbody;
    protected MovementState movementState;

    public override void EntityStart()
    {
        base.EntityStart();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public override void EntityUpdate()
    {
        base.EntityUpdate();

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
    /// Entity Movement by key
    /// </summary>
    public void KeyMovement()
    {
        Vector3 position = transform.position;

        // get new horizontal position
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0)
        {
            position.x += horizontalInput * MoveUnitPerSeconds * Time.deltaTime;
            transform.localScale = new Vector2(1f, 1f);
            movementState = MovementState.Right;
        }
        else if (horizontalInput < 0)
        {
            position.x += horizontalInput * MoveUnitPerSeconds * Time.deltaTime;
            transform.localScale = new Vector2(-1f, 1f);
            movementState = MovementState.Left;
        }

        // get new vertical position
        float verticalInput = Input.GetAxis("Vertical");
        if (verticalInput != 0)
        {
            position.y += verticalInput * MoveUnitPerSeconds * Time.deltaTime;
            if (verticalInput >= 0)
                movementState = MovementState.Forward;
            else if (verticalInput < 0)
                movementState = MovementState.Backward;

        }

        if(horizontalInput == 0 && verticalInput == 0)
        {
            movementState = MovementState.None;
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