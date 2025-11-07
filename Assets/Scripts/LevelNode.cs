using UnityEngine;
using System.Collections.Generic;

public class LevelNode : MonoBehaviour
{
    [System.Serializable]
    public class PathConnection
    {
        public string direction; // "up", "down", "left", "right"
        public LevelNode targetNode;
        public List<Transform> waypoints; // Waypoints along this path
    }

    public List<PathConnection> connections = new List<PathConnection>();
    public bool isUnlocked = true; // Can player access this node?
    
    // Visual feedback
    private SpriteRenderer spriteRenderer;
    public Sprite lockedSprite;
    public Sprite unlockedSprite;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateVisual();
    }

    public void UpdateVisual()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = isUnlocked ? unlockedSprite : lockedSprite;
        }
    }

    // Get the path for a given direction
    public PathConnection GetConnection(string direction)
    {
        foreach (PathConnection conn in connections)
        {
            if (conn.direction == direction && conn.targetNode.isUnlocked)
            {
                return conn;
            }
        }
        return null;
    }

    private void OnDrawGizmos()
    {
        // Draw lines to connected nodes in editor
        Gizmos.color = Color.yellow;
        foreach (PathConnection conn in connections)
        {
            if (conn.targetNode != null)
            {
                Gizmos.DrawLine(transform.position, conn.targetNode.transform.position);
            }
        }
    }
}