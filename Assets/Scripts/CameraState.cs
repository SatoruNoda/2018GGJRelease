using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraState : MonoBehaviour
{

	public Vector3 camera_pos1;
	public bool isTrakking1;
	public Vector3 camera_pos2;

	public GameObject Player;

	// Use this for initialization
	void Start ()
	{
		transform.position = camera_pos1;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (PlanetManager.GetState () == 2) {
			transform.position = camera_pos2
			+ calcPos (Player.transform.position, (new Vector3 (1, 1, 0)));
		}
	}

	private Vector3 calcPos (Vector3 a, Vector3 b)
	{
		Vector3 result = Vector3.zero;
		result.x = a.x * b.x;
		result.y = a.y * b.y;
		result.z = a.z * b.z;
		return result;
	}
}
