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

    private void Start()
    {
        Destroy(this.gameObject, LifeTime);
    }

    public void Setup(BaseGameEntity target, int damage)
    {
        this.target = target;
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (target == null)
            return;
        if (Direction == ProjectileDirection.FollowTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (DestroyOnApply)
        {
            Destroy(this.gameObject);
        }
    }
}
