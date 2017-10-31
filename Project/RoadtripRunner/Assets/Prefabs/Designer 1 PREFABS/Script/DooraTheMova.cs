using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DooraTheMova : MonoBehaviour {

	public Transform t_activeCamera;
	public Transform t_player;
	public float f_distance;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay (t_activeCamera.position, (t_player.position - t_activeCamera.position), Color.cyan);
		transform.position = (t_activeCamera.position + ((t_player.position - t_activeCamera.position).normalized * f_distance));
	}
}
