using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ProjectileDirection Direction;
    public float Speed;
    public float LifeTime;
    public float force;
    public float forceTime;
    public bool DestroyOnApply = true;

    protected BaseGameEntity target;
    private int damage;
    private bool isDestroying;
    private Vector2 goalPosition;
    private Vector2 direction;

    private void Start()
    {
        Destroy(this.gameObject, LifeTime);
    }

    public void Setup(BaseGameEntity target, int damage, Vector2 goalPosition)
    {
        this.target = target;
        this.damage = damage;
        this.goalPosition = goalPosition;
        isDestroying = false;
        direction = target.transform.position - transform.position;
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

                //Knockback
                KnockBack();

                if (DestroyOnApply && isDestroying)
                {
                    Destroy(this.gameObject);
                }
            }
        }
        else if (Direction == ProjectileDirection.TargetDirection)
        {
            transform.position = Vector3.MoveTowards(transform.position, goalPosition, Speed * Time.deltaTime);

            if (DestroyOnApply && isDestroying)
            {
                Destroy(this.gameObject);
            }
        }


    }

    private void KnockBack()
    {
        KnockbackFeedback knockbackFeedback = target.GetComponent<KnockbackFeedback>();
        if (knockbackFeedback != null)
        {
            knockbackFeedback.PlayFeedback(force, forceTime, direction);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {

        }
    }
}
