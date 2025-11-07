using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class overworld_movement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 3f;
    
    [Header("Current State")]
    public LevelNode currentNode;
    private bool isMoving = false;
    private List<Transform> currentPath;
    private int waypointIndex = 0;

    void Start()
    {
        // Start at initial node
        if (currentNode != null)
        {
            transform.position = currentNode.transform.position;
        }
    }

    void Update()
    {
        if (isMoving)
        {
            MoveAlongPath();
        }
        else
        {
            HandleInput();
        }
    }

    void HandleInput()
    {
        string direction = null;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = "up";
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = "down";
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = "left";
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = "right";
        }

        if (direction != null)
        {
            TryMove(direction);
        }
    }

    void TryMove(string direction)
    {
        LevelNode.PathConnection connection = currentNode.GetConnection(direction);
        
        if (connection != null)
        {
            StartMoving(connection);
        }
        else
        {
            Debug.Log("No path in that direction!");
        }
    }

    void StartMoving(LevelNode.PathConnection connection)
    {
        isMoving = true;
        currentPath = new List<Transform>(connection.waypoints);
        currentPath.Add(connection.targetNode.transform); // Add destination
        waypointIndex = 0;
    }

    void MoveAlongPath()
    {
        if (waypointIndex >= currentPath.Count)
        {
            // Reached destination
            ReachedNode();
            return;
        }

        Transform targetWaypoint = currentPath[waypointIndex];
        transform.position = Vector2.MoveTowards(
            transform.position, 
            targetWaypoint.position, 
            moveSpeed * Time.deltaTime
        );

        // Check if reached waypoint
        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.01f)
        {
            waypointIndex++;
        }
    }

    void ReachedNode()
    {
        isMoving = false;
        
        // Update current node to destination
        LevelNode.PathConnection lastConnection = currentNode.GetConnection(GetLastDirection());
        if (lastConnection != null)
        {
            currentNode = lastConnection.targetNode;
            transform.position = currentNode.transform.position;
            Debug.Log("Reached: " + currentNode.name);
        }
    }

    string GetLastDirection()
    {
        // Helper to get the direction we just moved
        // You might want to store this when starting movement
        return "up"; // Placeholder - improve this
    }
}