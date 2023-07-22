using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private WayPoints wayPoints;

    private Transform currentWayPoint;

    public float speed = 5f;
    void Start()
    {
        currentWayPoint = wayPoints.GetWayPoint(currentWayPoint);
        transform.position = currentWayPoint.position;
        //currentWayPoint = wayPoints.GetWayPoint(currentWayPoint);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentWayPoint != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentWayPoint.position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, currentWayPoint.position) < 0.1f)
            {

                currentWayPoint = wayPoints.GetWayPoint(currentWayPoint);
            }
        }
       
    }
}
