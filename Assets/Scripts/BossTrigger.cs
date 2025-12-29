using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public Animator bossAnimator;
    public MonoBehaviour bossScript;

    private bool activated = false;

    void Start()
    {
        if (bossAnimator != null)
        {
            bossAnimator.enabled = false;
        }

        if (bossScript != null)
        {
            bossScript.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (activated)
        {
            return;
        }

        if (collision.GetComponent<PlayerMovement>() != null)
        {
            ActivateBoss();
        }
    }

    void ActivateBoss()
    {
        activated = true;

        if (bossAnimator != null)
        {
            bossAnimator.enabled = true;
        }

        if (bossScript != null)
        {
            Debug.Log("Boss activated!");
            
            bossScript.enabled = true;
        }

        Destroy(gameObject);
    }
}
