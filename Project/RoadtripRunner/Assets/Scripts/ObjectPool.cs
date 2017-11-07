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
	private int m_numInPool = 0;
	private bool m_isActive;

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

	//activates the game object at a point in the scene
	//public GameObject Activate(int element, Vector3 position) {

	//}

	//deactivates it, returning it to the pool
	public void Deactivate(GameObject tmp) {
		tmp.SetActive(false);
	}

}
