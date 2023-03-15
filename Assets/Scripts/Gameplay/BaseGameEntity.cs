using UnityEngine;

public class BaseGameEntity : MonoBehaviour
{
    [Header("Data")]
    public BaseGameData data;
    
    protected IGameEntityComponent[] EntityComponents { get; private set; }
    protected virtual bool UpdateEntityComponents { get { return true; } }
    public IEntityMovement Movement { get; set; }

    public BaseGameEntity target;

    public ModelController ModelController;
    
    private void Awake()
    {
        InitialRequiredComponents();
        EntityComponents = GetComponents<IGameEntityComponent>();
        ModelController = GetComponentInChildren<ModelController>();
        Movement = GetComponent<IEntityMovement>();
        for (int i = 0; i < EntityComponents.Length; ++i)
        {
            EntityComponents[i].EntityAwake();
            EntityComponents[i].Enabled = true;
        }
        EntityAwake();

    }

    public virtual void InitialRequiredComponents()
    {
    }

    protected virtual void EntityAwake() { }

    private void Start()
    {
        for (int i = 0; i < EntityComponents.Length; ++i)
        {
            if (EntityComponents[i].Enabled)
                EntityComponents[i].EntityStart();
        }
        EntityStart();
    }

    protected virtual void EntityStart() { }

    private void Update()
    {
        if (UpdateEntityComponents)
        {
            for (int i = 0; i < EntityComponents.Length; ++i)
            {
                if (EntityComponents[i].Enabled)
                    EntityComponents[i].EntityUpdate();
            }
        }
        EntityUpdate();
    }

    protected virtual void EntityUpdate()
    {

    }

    private void LateUpdate()
    {
        if (UpdateEntityComponents)
        {
            for (int i = 0; i < EntityComponents.Length; ++i)
            {
                if (EntityComponents[i].Enabled)
                    EntityComponents[i].EntityLateUpdate();
            }
        }
        EntityLateUpdate();
    }

    protected virtual void EntityLateUpdate()
    {

    }

    private void FixedUpdate()
    {
        if (UpdateEntityComponents)
        {
            for (int i = 0; i < EntityComponents.Length; ++i)
            {
                if (EntityComponents[i].Enabled)
                    EntityComponents[i].EntityFixedUpdate();
            }
        }
        EntityFixedUpdate();
    }

    protected virtual void EntityFixedUpdate() { }

    public virtual float GetMoveSpeed()
    {
        return 0;
    }

    public virtual bool CanMove()
    {
        return false;
    }

    public virtual bool IsHide()
    {
        return false;
    }
}
