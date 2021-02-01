using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageArea : MonoBehaviour
{


	void OnTriggerExit (Collider c)
	{
		if ("Player".Equals (c.tag)) {
			PlanetManager.Over ();
		}
	}
}
