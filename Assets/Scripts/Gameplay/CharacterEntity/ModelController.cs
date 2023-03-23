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
        animator.SetBool("IsHit", true);
    }

    public void OnDead()
    {
        animator.SetTrigger("Death");
    }

    public void OnHitted()
    {
        animator.SetBool("IsHit", false);
    }
}
