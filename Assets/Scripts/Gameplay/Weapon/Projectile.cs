using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ProjectileDirection Direction;
    public float Speed;
    public float LifeTime;
    public bool DestroyOnApply = true;

    protected BaseGameEntity target;
    private int damage;
    private bool isDestroying;
    private Vector2 oldGoal;
    private LayerMask enemyLayer;

    private void Start()
    {
        Destroy(this.gameObject, LifeTime);
    }

    public void Setup(BaseGameEntity target, int damage)
    {
        this.target = target;
        this.damage = damage;
        isDestroying = false;
        oldGoal = target.transform.position;
        enemyLayer = target.gameObject.layer;
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (target == null)
        {
            Destroy(this.gameObject);
            return;
        }

        Vector3 goal = target.transform.position;
        if (target == null)
            return;
        if (Direction == ProjectileDirection.FollowTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, goal, Speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, goal) <= 0 && target is DamageableEntity damageableTarget && !isDestroying)
            {
                isDestroying = true;
                damageableTarget.ApplyDamage(damage);
                if (DestroyOnApply && isDestroying)
                {
                    Destroy(this.gameObject);
                }
            }
        }
        else if (Direction == ProjectileDirection.TargetDirection)
        {
            transform.position = Vector3.MoveTowards(transform.position, oldGoal, Speed * Time.deltaTime);

            if (DestroyOnApply && isDestroying)
            {
                Destroy(this.gameObject);
            }
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(LayermaskExtensions.Contains(enemyLayer, collision.gameObject))
        {

        }
    }
}
