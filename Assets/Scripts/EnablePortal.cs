using UnityEngine;

public class EnablePortal : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Boss boss;
    private bool portalEnabled = false;

    private MonoBehaviour exitPortalScript;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        exitPortalScript = GetComponent<ExitPortal>();

        // Hide the portal initially
        if (spriteRenderer != null)
        {            
            spriteRenderer.enabled = false;
        }

        if (exitPortalScript != null)
        {
            exitPortalScript.enabled = false;
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
            exitPortalScript.enabled = true;
        }
    }
}
