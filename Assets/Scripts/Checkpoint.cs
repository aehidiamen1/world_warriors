using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Sprite greySprite;
    public Sprite coloredSprite;
    private SpriteRenderer spriteRenderer;
    private bool isActivated = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = greySprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isActivated && other.CompareTag("Player"))
        {
            isActivated = true;
            spriteRenderer.sprite = coloredSprite;
            Debug.Log("Checkpoint activated!");
        }
    }
}
