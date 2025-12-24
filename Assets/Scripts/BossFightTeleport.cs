using UnityEngine;

public class BossFightTeleport : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool portalActive = false;
    private bool portalSpawned = false;
    private bool appear = false;
    
    public ObeliskActivator[] obelisks;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        // Hide the portal initially
        if (spriteRenderer != null) spriteRenderer.enabled = false;
    }

    void Update()
    {
        if (portalSpawned) return;
        
        if (AllObelisksActivated())
        {
            portalSpawned = true;
            ActivatePortal();
        }
    }

    private bool AllObelisksActivated()
    {
        if (obelisks == null || obelisks.Length == 0)
        {
            Debug.LogWarning("No obelisks assigned to portal!");
            return false;
        }
        
        foreach (var obelisk in obelisks)
        {
            if (obelisk == null || !obelisk.IsActivated)
            {
                return false;
            }
        }
        
        return true;
    }

    private void ActivatePortal()
    {
        if (spriteRenderer != null) spriteRenderer.enabled = true;
        

        if (animator != null && spriteRenderer.enabled == true)
        {
            animator.SetTrigger("Appear");
        }
    }

    public void SetToIdle()
    {
        if (animator != null)
        {
            animator.SetTrigger("Idle");
        }
    }
}