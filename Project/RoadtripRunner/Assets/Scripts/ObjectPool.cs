using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ObjectPool : MonoBehaviour {

	//stores the type/number of a given object
	[System.Serializable]
	public class ObjectsForPool : System.Object{
		public GameObject m_object;
		public int m_numOfThisType;
	}

	public List<ObjectsForPool> m_UserSetObjects;

	private List<GameObject> m_pooledObjects;

	// Use this for initialization
	void Start() {
		m_pooledObjects = new List<GameObject>();

		//loops for number of pooled objects, adds to the pool and sets active to false
		for(int i = 0; i < m_UserSetObjects.Count; i++) {
			for(int j = 0; j < m_UserSetObjects[i].m_numOfThisType; j++) {
				GameObject tmp = (GameObject)Instantiate(m_UserSetObjects[i].m_object);
				tmp.SetActive(false);
				m_pooledObjects.Add(tmp);
			}
		}
	}

	//checks if given element is active in the scene already, returns true if it is, false otherwise
	bool IsActive(int element) {
		if(m_pooledObjects[element].activeInHierarchy == true) {
			return true;
		}
		return false;
	}

	//activates the game object at a point in the scene
	public GameObject Activate(int element, Vector3 position) {
		m_pooledObjects[element].SetActive(true);
		m_pooledObjects[element].transform.position = position;
		return m_pooledObjects[element];
	}

	//deactivates it, returning it to the pool
	public void Deactivate(GameObject tmp) {
		tmp.SetActive(false);
	}

}
