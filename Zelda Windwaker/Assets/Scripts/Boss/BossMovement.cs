using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private Transform target;

    private int waypointIndex = 0;

    void Start()
    {
        target = Waypoints.points[0];
    }
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }
    void GetNextWaypoint()
    {
 
       
        waypointIndex++;
        target = Waypoints.points[waypointIndex];
        if (waypointIndex == 7)
        {
            waypointIndex = 0;
        }
    }

}