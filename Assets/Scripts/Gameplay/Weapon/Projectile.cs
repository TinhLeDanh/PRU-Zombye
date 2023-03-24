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
    public bool DestroyOnApplyWall = true;
    public GameObject explosionPrefab;

    protected BaseGameEntity target;
    protected BaseGameEntity caster;
    private int damage;
    private Vector2 goalPosition;
    private Vector2 direction;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Destroy(this.gameObject, LifeTime);
    }

    public void Setup(BaseGameEntity caster, BaseGameEntity target, int damage, Vector2 goalPosition)
    {
        this.caster = caster;
        this.target = target;
        this.damage = damage;
        this.goalPosition = goalPosition;
        direction = Vector2.up;
        if (target != null)
            direction = goalPosition - (Vector2)transform.position;

        if (Direction == ProjectileDirection.TargetDirection)
        {
            direction = direction.normalized;
            rb.AddForce(Speed * direction, ForceMode2D.Impulse);
        }
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
        }
        else if (Direction == ProjectileDirection.TargetDirection)
        {
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") && DestroyOnApplyWall)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Monster"))
        {
            if (target is DamageableEntity damageableTarget && target.Movement.MovementState != MovementState.Dead
                && target is MonsterCharacterEntity)
            {
                Instantiate(explosionPrefab, collision.gameObject.transform.position, Quaternion.identity);
                damageableTarget.ApplyDamage(caster, damage);
                //Knockback
                KnockBack();
            }
        }

        if (collision.gameObject.CompareTag("Player") && target is BasePlayerCharacterEntity)
        {
            if (DestroyOnApply)
            {
                if (target is DamageableEntity damageableTarget)
                {
                    Instantiate(explosionPrefab, collision.gameObject.transform.position, Quaternion.identity);
                    damageableTarget.ApplyDamage(caster, damage);
                }

                Destroy(this.gameObject);
            }
        }
    }
}