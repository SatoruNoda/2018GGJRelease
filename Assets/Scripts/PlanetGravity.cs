using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour
{
	
	public float start = 0;
	public float end = 100;

	// MUST SphereCollier
	// MUST Player Rigidbody


	void OnTriggerStay (Collider other)
	{
		if (!"Player".Equals (other.tag)) {
			return;
		}
		Rigidbody player_rd = other.GetComponent<Rigidbody> ();
		Vector3 player_pos = other.transform.position;
		player_rd.AddForce (MathForce (player_pos));
	}

	private float GetRadiusSize ()
	{
		SphereCollider c = GetComponent<SphereCollider> ();
		return c.radius;
	}

	private float PlayerDist (Vector3 player)
	{
		Vector3 planet = transform.position;
		return (planet - player).magnitude;
	}

	private Vector3 PlayerVector (Vector3 player)
	{
		Vector3 planet = transform.position;
		return (planet - player).normalized;
	}

	private Vector3 MathForce (Vector3 player)
	{
		float parcent = PlayerDist (player) / GetRadiusSize ();
		float force = Mathf.Clamp (parcent, start, end);
		return force * PlayerVector (player);
	}
		
}
