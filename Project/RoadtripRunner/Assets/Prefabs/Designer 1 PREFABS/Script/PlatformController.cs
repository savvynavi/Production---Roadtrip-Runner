using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlatformController : MonoBehaviour {

	public Transform m_platformFocalPoint;

	public Transform m_activeCamera;
    public Transform SetCamera { get; set; }

	public float m_speed;
	public float SetSpeed {get;set;}

	private Rigidbody m_rigidbody;
	private Vector3 m_direction;
	public Transform m_platformPos;

	public Transform startOfPlatform;
	public Transform endOfPlatform;



	// Use this for initialization
	void Start () {
		m_rigidbody = GetComponent<Rigidbody>();
		SetSpeed = m_speed;
		SetCamera = m_activeCamera;
	}
	

	void FixedUpdate() {
		SetDirection();
        RaycastHit hit;
        //raycast from camera to platformFocalPoint
        Debug.DrawRay(m_activeCamera.position, (m_platformFocalPoint.position - m_activeCamera.position), Color.red);


		Vector3 viewPos = Camera.main.WorldToViewportPoint(startOfPlatform.position);
		Vector3 viewPos2 = Camera.main.WorldToViewportPoint (endOfPlatform.position);
		if(viewPos.x > 0 || viewPos2.x > 0) {
			if(Physics.Raycast(m_activeCamera.position, (m_platformFocalPoint.position - m_activeCamera.position), out hit)) {
				m_platformPos.position = hit.point;
				Debug.DrawRay(hit.point, (m_platformFocalPoint.position - hit.point), Color.green);
			}
		}

		if(transform.position.z == m_platformPos.position.z) {
			SetSpeed = 0;
		} else {
			SetSpeed = m_speed;
		}

		//actual movement code
		m_rigidbody.MovePosition(m_rigidbody.position + m_direction * m_speed * Time.deltaTime);
	}

	//sets the direction of the platform movement
	void SetDirection() {
		m_direction = (m_platformPos.position - m_rigidbody.position);

	}

	//testing pos stuff
	void OnDrawGizmos() {
		if(transform.position.z > m_platformPos.position.z) {
			Gizmos.color = Color.green;
		}else if(transform.position.z < m_platformPos.position.z) {
			Gizmos.color = Color.red;
		}else if(transform.position.z == m_platformPos.position.z) {
			Gizmos.color = Color.blue;
		}
		Gizmos.DrawWireCube(transform.position, m_platformPos.localScale);
	}
}
