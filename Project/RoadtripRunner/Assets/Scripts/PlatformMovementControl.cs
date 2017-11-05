using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
public class PlatformMovementControl : MonoBehaviour {
	
	public Transform m_platform;
	public Transform m_startTransform;
	public Transform m_endTransform;
	public float m_speed;

	private Vector3 m_direction;
	private Transform m_destination;

	void Start() {
		SetDestination(m_startTransform);
	}

	//physic calculations need to go in fixed update
	void FixedUpdate() {
		//to keep movement smooth, using rigidbody.moveposition()
		m_platform.GetComponent<Rigidbody>().MovePosition(m_platform.position + m_direction * m_speed * Time.fixedDeltaTime);

		//this just turns it around, for testing purposes(won't be needed in final product)
		if(Vector3.Distance(m_platform.position, m_destination.position) < m_speed * Time.fixedDeltaTime) {
			SetDestination(m_destination == m_startTransform ? m_endTransform : m_startTransform);
		}
	}

	//draws the empty start/end objects, so easier to position
	void OnDrawGizmos() {
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(m_startTransform.position, m_platform.localScale);

		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(m_endTransform.position, m_platform.localScale);
	}

	//sets the destination, won't be needed in final product most likely(if camera does what I think it does)
	void SetDestination(Transform dest) {
		m_destination = dest;
		m_direction = (m_destination.position - m_platform.position).normalized;

	}
}
