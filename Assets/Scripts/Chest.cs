using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator animator;
    private bool isOpened = false;
    [SerializeField]
    private FloatSO coinCountSO;

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
            if (CompareTag("BrownChest"))
            {
                coinCountSO.Value += 10;
            }
            else if (CompareTag("BlackChest"))
            {
                coinCountSO.Value += 20;
            }
            else if (CompareTag("RedChest"))
            {
                coinCountSO.Value += 30;
            }
            else if (CompareTag("WhiteChest"))
            {                 
                coinCountSO.Value += 40;
            }
        }
    }
}
