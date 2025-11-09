using UnityEngine;
using System.Collections.Generic;

public class OverworldPath : MonoBehaviour
{
    //Storing the path points in a list
    public List<Transform> pathPoints = new List<Transform>();

    public Vector3[] GetPathPositions()
    {
        Vector3[] positions = new Vector3[pathPoints.Count];
        for (int i = 0; i < pathPoints.Count; i++)
            positions[i] = pathPoints[i].position;
        return positions;
    }
}
