using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicSizer : MonoBehaviour
{
    public Transform firstPoint;
    public Transform secondPoint;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        if (firstPoint == null || secondPoint == null) { return; }

        Vector3 centerPos = transform.position;
        centerPos.x = firstPoint.position.x + secondPoint.position.x / 2;

        transform.position = centerPos;

        float scaleX = Mathf.Abs(firstPoint.position.x - secondPoint.position.x);

        transform.position = centerPos;
        //transform.localScale = new Vector3(scaleX, 1, 1);
    }
}
