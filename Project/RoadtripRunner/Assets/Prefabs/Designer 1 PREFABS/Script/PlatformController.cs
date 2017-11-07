using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlatformController : MonoBehaviour {

	public Transform t_platformFocalPoint;

	public Transform t_activeCamera;

	public float m_speed;
	public float SetSpeed {get;set;}

	private Rigidbody m_rigidbody;
	private Vector3 m_direction;
	public Transform m_platformPos;
	public Vector3 TestPos;

	// Use this for initialization
	void Start () {
		m_rigidbody = GetComponent<Rigidbody>();
		SetSpeed = m_speed;
	}
	

	void FixedUpdate() {
            SetDirection();
            RaycastHit hit;
            //raycast from camera to platformFocalPoint
            Debug.DrawRay(t_activeCamera.position, (t_platformFocalPoint.position - t_activeCamera.position), Color.red);

        float width = GetComponent<MeshFilter>().mesh.bounds.size.x / 2;
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        if (viewPos.x > 0 + width && viewPos.x < 1 - width)
        {
            if (Physics.Raycast(t_activeCamera.position, (t_platformFocalPoint.position - t_activeCamera.position), out hit))
            {
                m_platformPos.position = hit.point;
                Debug.DrawRay(hit.point, (t_platformFocalPoint.position - hit.point), Color.green);
            }
        }

            if (transform.position.z == m_platformPos.position.z)
            {
                SetSpeed = 0;
            }
            else
            {
                SetSpeed = m_speed;
            }

            //actual movement code
            m_rigidbody.MovePosition(m_rigidbody.position + m_direction * m_speed * Time.deltaTime);

            TestPos = m_platformPos.position;
	}

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
