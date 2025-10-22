using UnityEngine;
using System.Collections;

public class Mushroom_explosion : MonoBehaviour
{
    private Animator animator;
    private bool isExploding = false;

    [SerializeField]
    private float cooldownTime = 2f; // time before resetting to idle

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isExploding)
        {
            isExploding = true;
            animator.SetTrigger("Explode");
            StartCoroutine(ResetAfterExplosion());
        }
    }

    private IEnumerator ResetAfterExplosion()
    {
        // Wait for the explosion animation to finish
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Wait for additional cooldown
        yield return new WaitForSeconds(cooldownTime);

        // Reset to idle
        animator.Play("Idle mushroom");
        isExploding = false;
    }
}
