using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    private Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Get the position of the player
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    public void SpawnDroppedItem()
    {
        // Drop the item a set postion away from the player
        Vector2 playerPos = new Vector2(player.position.x + 1, player.position.y - 0.5f);
        Quaternion itemRotation = item.transform.rotation;
        Instantiate(item, playerPos, itemRotation);
    }
}
