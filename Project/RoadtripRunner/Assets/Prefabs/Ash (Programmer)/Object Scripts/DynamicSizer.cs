using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicSizer : MonoBehaviour
{
    public Transform firstPoint;
    public Transform secondPoint;
    public float yPos;
    public float zPos;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        if (firstPoint == null || secondPoint == null) { return; }

        float scaleMultiplier = Vector3.Distance(firstPoint.position, secondPoint.position) / transform.lossyScale.x;

        transform.position = new Vector3(Mathf.Lerp(firstPoint.position.x, secondPoint.position.x, 0.5f), yPos, zPos);
        transform.localScale = new Vector3(transform.localScale.x * scaleMultiplier, transform.localScale.y, transform.localScale.z);
    }
}
