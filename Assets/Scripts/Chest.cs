using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator animator;
    private bool isOpened = false;
    public CoinManager CoinManager;

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
                CoinManager.coinCount += 10;
            }
            else if (CompareTag("BlackChest"))
            {
                CoinManager.coinCount += 20;
            }
            else if (CompareTag("RedChest"))
            {
                CoinManager.coinCount += 30;
            }
            else if (CompareTag("WhiteChest"))
            {                 
                CoinManager.coinCount += 40;
            }
        }
    }
}
