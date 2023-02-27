using UnityEngine;
public interface IEntityMovement : IGameEntityComponent
{
    BaseGameEntity Entity { get; }
    float StoppingDistance { get; }
    MovementState MovementState { get; }
    float CurrentMoveSpeed { get; }
    void StopMove();
    void KeyMovement();
    void PointClickMovement();
    void SetLookRotation(Quaternion rotation);
    Quaternion GetLookRotation();
    void SetSmoothTurnSpeed(float speed);
    float GetSmoothTurnSpeed();
    void Teleport(Vector3 position, Quaternion rotation);
    bool FindGroundedPosition(Vector3 fromPosition, float findDistance, out Vector3 result);
}
