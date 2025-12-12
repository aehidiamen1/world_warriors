using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverworldController : MonoBehaviour
{
    public Transform cursorTransform;
    public OverworldNode currentNode;
    public float moveSpeed = 5f;

    private bool isMoving = false;
    private const string lastNode = "LastOverworldNode";

    void Start()
    {
        // Check if returning from a level
        string savedNodeName = PlayerPrefs.GetString(lastNode, "");
        
        if (!string.IsNullOrEmpty(savedNodeName))
        {
            OverworldNode savedNode = FindNodeByName(savedNodeName);
            if (savedNode != null)
            {
                currentNode = savedNode;
                cursorTransform.position = currentNode.transform.position;
            }
            PlayerPrefs.DeleteKey(lastNode);
        }
        else if (cursorTransform != null && currentNode != null)
        {
            cursorTransform.position = currentNode.transform.position;
        }
    }

    OverworldNode FindNodeByName(string nodeName)
    {
        foreach (OverworldNode node in FindObjectsOfType<OverworldNode>())
        {
            if (node.name == nodeName)
                return node;
        }
        return null;
    }

    void Update()
    {
        if (isMoving) return;

        for (int i = 0; i < currentNode.connectedNodes.Count; i++)
        {
            if (i >= currentNode.connectionKeys.Count) continue;

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
            PlayerPrefs.SetString(lastNode, currentNode.name);
            PlayerPrefs.Save();
            SceneManager.LoadScene(currentNode.levelSceneName);
        } 
    }

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