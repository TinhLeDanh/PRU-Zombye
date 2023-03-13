using UnityEngine;

public class ModelController : MonoBehaviour
{
    private Animator animator;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnHit()
    {
        animator.SetTrigger("Hit");
    }

    public void OnDead()
    {
        animator.SetTrigger("Dead");
    }
}
