using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugForce : MonoBehaviour
{

	public static bool isShoot = false;
	public static bool isDebug = false;
	public static float force = 0f;

	public void Onclick ()
	{
		isShoot = true;
	}

	public void Change (float f)
	{
		force = f;
	}
}
