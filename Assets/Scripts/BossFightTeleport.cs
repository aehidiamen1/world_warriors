using UnityEngine;

public class BossFightTeleport : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;              
    private bool portalSpawned = false;
    
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
            ActivatePortal();
            portalSpawned = true;
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
        Debug.Log("All obelisks activated! Spawning portal...");
        // Show the portal
        if (animator != null && spriteRenderer != null)
        {
            animator.SetTrigger("Appear");
            spriteRenderer.enabled = true;
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