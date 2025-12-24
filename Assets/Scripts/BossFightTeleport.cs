using UnityEngine;

public class BossFightTeleport : MonoBehaviour
{
    private Animator animator;
    private bool portalActive = false;
    private bool portalSpawned = false;
    private bool appear = false;
    
    public ObeliskActivator[] obelisks;

    void Start()
    {
        animator = GetComponent<Animator>();
        
        // Hide the portal initially
        gameObject.SetActive(false);
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
        gameObject.SetActive(true);
        
        if (animator != null)
        {
            animator.SetTrigger("Appear");
            appear = true;
        }

        if (appear == true)
        {
            animator.SetTrigger("Idle");
        }
    }
}