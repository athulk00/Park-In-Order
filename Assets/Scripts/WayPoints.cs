using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    [SerializeField] public Transform[] wayPointTransforms;
    public void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = wayPointTransforms.Length;
      
    }
    private void Update()
    {
        for (int i = 0; i < wayPointTransforms.Length; i++)
        {
            _lineRenderer.SetPosition(i, wayPointTransforms[i].position);
        }
    }
     private void OnDrawGizmos()
     {
         foreach(Transform t in transform)
         {
             Gizmos.color = Color.blue;
             Gizmos.DrawWireSphere(t.position, 1f);
         }
         Gizmos.color = Color.red;
         for(int i = 0; i< transform.childCount -1; i++)
         {
             Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
         }
     }
    public Transform GetWayPoint(Transform currentWayPoint)
    {
        if(currentWayPoint == null)
        {
            return transform.GetChild(0);
        }
        if(currentWayPoint.GetSiblingIndex() < transform.childCount - 1)
        {
            return transform.GetChild(currentWayPoint.GetSiblingIndex() + 1);
        }
        if(currentWayPoint.GetSiblingIndex() == transform.childCount)
        {
            
        }
        return null;
    }
}
