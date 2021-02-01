using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

	public GameObject Helper;
	public bool isMove;
	public float FORCE = 0.01f;

	// Use this for initialization
	void Start ()
	{
		isMove = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		InputHelper helper = Helper.GetComponent<InputHelper> ();
		float time = helper.time;
		if (time > 0 && !isMove) {
			Vector3 forceVec = helper.Get ();
			forceVec.z = 0;
			float force = forceVec.magnitude;
			GetComponent<Rigidbody> ().AddForce (force * forceVec.normalized * FORCE);
			isMove = true;
			PlanetManager.NextState ();
		}
	}
}
