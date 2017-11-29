using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicSizer : MonoBehaviour
{
    public Vector3 firstPoint;
    public Vector3 secondPoint;
    public float yPos;
    public float zPos;

	
	void Update ()
    {
        if (firstPoint == null || secondPoint == null) { return; }

        float scaleMultiplier = Vector3.Distance(firstPoint, secondPoint) / transform.lossyScale.x;

        transform.position = new Vector3(Mathf.Lerp(firstPoint.x, secondPoint.x, 0.5f), yPos, zPos);
        transform.localScale = new Vector3(transform.localScale.x * scaleMultiplier, transform.localScale.y, transform.localScale.z);
    }
}
