[System.Flags]
public enum MovementState : byte
{
    None = 0,
    Forward = 1 << 0,
    Backward = 1 << 1,
    Left = 1 << 2,
    Right = 1 << 3,
    Dead = 1 << 4,
}

public static class MovementStateExtensions
{
    public static bool Has(this MovementState self, MovementState flag)
    {
        return (self & flag) == flag;
    }

    public static bool HasDirectionMovement(this MovementState self)
    {
        return self.Has(MovementState.Forward) ||
            self.Has(MovementState.Backward) ||
            self.Has(MovementState.Right) ||
            self.Has(MovementState.Left);
    }
}
