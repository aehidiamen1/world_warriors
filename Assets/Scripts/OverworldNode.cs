using UnityEngine;
using System.Collections.Generic;

public class OverworldNode : MonoBehaviour
{
    // List of nodes this one connects to
    public List<OverworldNode> connectedNodes = new List<OverworldNode>();

    // List of paths to follow for each connection
    public List<OverworldPath> connectionPaths = new List<OverworldPath>();
    //List of the arrow to press to go between connections
    public List<KeyCode> connectionKeys = new List<KeyCode>();

    // Is this node a playable level or just a crossroad?
    public bool isLevel = false;
    public string levelSceneName;
    private void OnDrawGizmos()
    {
        // Draw the node itself
        Gizmos.color = isLevel ? Color.yellow : Color.white;
        Gizmos.DrawSphere(transform.position, 0.3f);

        // Draw lines to connected nodes along paths
        Gizmos.color = Color.cyan;
        for (int i = 0; i < connectedNodes.Count; i++)
        {
            var node = connectedNodes[i];
            var path = connectionPaths.Count > i ? connectionPaths[i] : null;

            if (node != null)
            {
                if (path != null && path.pathPoints.Count > 0)
                {
                    // Draw along path points
                    Vector3 prev = transform.position; // start at this node
                    foreach (var point in path.pathPoints)
                    {
                        if (point != null)
                        {
                            Gizmos.DrawLine(prev, point.position);
                            prev = point.position;
                        }
                    }
                    // Final line to the neighbor node
                    Gizmos.DrawLine(prev, node.transform.position);
                }
                else
                {
                    // Fallback: straight line
                    Gizmos.DrawLine(transform.position, node.transform.position);
                }
            }
        }
    }
}
