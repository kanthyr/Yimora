using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform camposition;
    public List<Transform> targets;
    public Vector3 offset;

    void LateUpdate()
    {
        Vector3 centerpoint = GetCenterPoint();

        Vector3 newpos = centerpoint + offset;

        camposition.position = newpos;
    }

    private Vector3 GetCenterPoint()
    {
        var bound = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bound.Encapsulate(targets[i].position);
        }

        return bound.center;
    }
}
