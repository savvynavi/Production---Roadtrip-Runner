using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

	public Transform t_platformFocalPoint;

	public Transform t_activeCamera;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		//raycast from camera to platformFocalPoint
		Debug.DrawRay (t_activeCamera.position, (t_platformFocalPoint.position - t_activeCamera.position), Color.red);
		if (Physics.Raycast (t_activeCamera.position, (t_platformFocalPoint.position - t_activeCamera.position), out hit)) 
		{
			transform.position = hit.point;
		}
		transform.position = new Vector3(transform.position.x, transform.position.y, 0);
	}
		
}
