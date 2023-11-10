using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Vector2> points;
    public static List<Vector2> pointList;
    void Awake()
    {
        pointList = points;
    }

    private void Start()
    {
        pointList = points;
    }

    public void OnDrawGizmos()
    {
        foreach (var point in points) {
            Gizmos.DrawSphere(point, 0.05f);
        }
    }
}
