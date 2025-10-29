using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator animator;
    private bool isOpened = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isOpened && other.CompareTag("Player"))
        {
            isOpened = true;
            animator.SetTrigger("Open");
        }
    }
}
