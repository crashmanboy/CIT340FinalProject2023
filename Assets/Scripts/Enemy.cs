using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speedPerSecond = 2.0f;
    public float distanceThreshold = 0.3f;

    private Vector2 targetWaypoint;
    private int wayPointIndex;

    private SpriteRenderer sr;


    // Start is called before the first frame update
    void Start()
    {
        wayPointIndex = 0;
        targetWaypoint = WaypointManager.pointList[wayPointIndex];
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 directionToMove = targetWaypoint - (Vector2)transform.position;
        float distance = directionToMove.magnitude;

        if (distance < distanceThreshold)
        {
            if (wayPointIndex == WaypointManager.pointList.Count - 1)
            {
                return;
            }
            targetWaypoint = WaypointManager.pointList[++wayPointIndex];
            directionToMove = targetWaypoint - (Vector2)transform.position;
        }

        //Normalize and apply the correct force
        directionToMove.Normalize();
        transform.Translate(directionToMove * speedPerSecond * Time.deltaTime);
        //Orient in the right direction
        //var sr = GetComponentInChildren<SpriteRenderer>();
        if (directionToMove.x > 0.01)
        {
            sr.flipX = true;

        }
        else
        {
            sr.flipX = false;
        }
        if (directionToMove.y > 0.5)
        {//This rotates the entire object reference, and so creates problems with movemen
         // var tr=transform.GetChild(0).GetComponent<Transform>();
         // tr.Rotate(new Vector3(0, 0, 90));
         //transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
    }
}

