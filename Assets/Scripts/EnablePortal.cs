using UnityEngine;

public class EnablePortal : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Boss boss;
    private bool portalEnabled = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boss = GetComponent<Boss>();

        // Hide the portal initially
        if (spriteRenderer != null)
        {            
            spriteRenderer.enabled = false;
        }
    }

    void Update()
    {
        if (portalEnabled)
            return;

        if (boss.currentHealth <= 0 && portalEnabled == false)
        {
            spriteRenderer.enabled = true;
            portalEnabled = true;
        }
    }
}
