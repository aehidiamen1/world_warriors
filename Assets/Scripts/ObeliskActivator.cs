using UnityEngine;

public class ObeliskActivator : MonoBehaviour
{
    private Animator animator;
    private bool activated = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Activates the obelisk when the player walks past it
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (activated)
        {
            return;
        }
        
        if (other.CompareTag("Player"))
        {
            activated = true;

            if (animator != null)
            {
                animator.SetTrigger("Activated");
            }
        }
    }
}
