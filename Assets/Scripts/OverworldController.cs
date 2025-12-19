using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverworldController : MonoBehaviour
{
    public Transform cursorTransform;
    public OverworldNode currentNode;
    public float moveSpeed = 5f;

    private bool isMoving = false;

    void Start()
    {       
            // Start at default start node if not returning from a level
            if (cursorTransform != null && currentNode != null)
            {
                cursorTransform.position = currentNode.transform.position;
            }
    }

    // Finds a node by its name in the scene
    OverworldNode FindNodeByName(string nodeName)
    {
        foreach (OverworldNode node in FindObjectsOfType<OverworldNode>())
        {
            if (node.name == nodeName)
                return node;
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving) return;

        for (int i = 0; i < currentNode.connectedNodes.Count; i++)
        {
            if (i >= currentNode.connectionKeys.Count) continue;

            // Moving to connected node
            if (Input.GetKeyDown(currentNode.connectionKeys[i]))
            {
                var targetNode = currentNode.connectedNodes[i];
                var path = currentNode.connectionPaths.Count > i ? currentNode.connectionPaths[i] : null;

                if (targetNode != null && path != null)
                    StartCoroutine(MoveAlongPath(path, targetNode));
                return;
            }
        }

        // Entering the level
        if (Input.GetKeyDown(KeyCode.Return) && currentNode.isLevel)
        {
            Debug.Log("Enter Level: " + currentNode.name);
            SceneManager.LoadScene(currentNode.levelSceneName);
        } 
    }

    
    // Coroutine to move the player icon along a specified path to the target node
    IEnumerator MoveAlongPath(OverworldPath path, OverworldNode targetNode)
    {
        isMoving = true;
        Vector3 startPos = cursorTransform.position;

        foreach (var point in path.pathPoints)
        {
            if (point == null) continue;

            Vector3 endPos = point.position;
            float distance = Vector3.Distance(startPos, endPos);
            float t = 0f;

            while (t < 1f)
            {
                t += Time.deltaTime * moveSpeed / distance;
                cursorTransform.position = Vector3.Lerp(startPos, endPos, t);
                yield return null;
            }

            startPos = endPos;
        }

        // Final move to target node
        Vector3 finalStart = startPos;
        Vector3 finalEnd = targetNode.transform.position;
        float finalDistance = Vector3.Distance(finalStart, finalEnd);
        float finalT = 0f;

        // Move to the final target node position
        while (finalT < 1f)
        {
            finalT += Time.deltaTime * moveSpeed / finalDistance;
            cursorTransform.position = Vector3.Lerp(finalStart, finalEnd, finalT);
            yield return null;
        }

        currentNode = targetNode;
        isMoving = false;
    }
}