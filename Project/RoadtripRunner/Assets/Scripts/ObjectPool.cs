using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ObjectPool : MonoBehaviour {

	public Transform m_testPos;

	//stores the type/number of a given object
	[System.Serializable]
	public class ObjectsForPool : System.Object{
		public GameObject m_object;
		public int m_numOfThisType;
	}

	public List<ObjectsForPool> m_UserSetObjects;
	public Camera m_camera;
	private PlatformController m_platform;

	private List<GameObject> m_pooledObjects = null;

	// Use this for initialization
	void Start() {
		m_pooledObjects = new List<GameObject>();
		m_camera = Camera.main;

		//loops for number of pooled objects, adds to the pool and sets active to false
		for(int i = 0; i < m_UserSetObjects.Count; i++) {
			for(int j = 0; j < m_UserSetObjects[i].m_numOfThisType; j++) {
				GameObject tmp = (GameObject)Instantiate(m_UserSetObjects[i].m_object);
				Deactivate(tmp);
				m_pooledObjects.Add(tmp);
			}
		}

		//test activation delete later
		Activate(4, m_testPos);
	}

	//checks if given element is active in the scene already, returns true if it is, false otherwise
	bool IsActive(int element) {
		if(m_pooledObjects[element].activeInHierarchy == true) {
			return true;
		}
		return false;
	}

	//activates the game object at a point in the scene
	public GameObject Activate(int element, Transform transform) {
		if(IsActive(element) == false) {
			GameObject currentObject = m_pooledObjects[element];
			currentObject.SetActive(true);
			currentObject.transform.position = transform.position;
			currentObject.transform.rotation = transform.rotation;
			return currentObject;
		}
		return null;
	}

	//deactivates it, returning it to the pool
	public void Deactivate(GameObject tmp) {
		tmp.SetActive(false);
	}
}
