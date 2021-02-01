using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInput : MonoBehaviour
{

	public GameObject player;
	public GameObject camera_obj;
	public static Vector3 debugVector = Vector3.zero;
	public static bool isDebug = false;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isDebug && Input.GetMouseButton (0)) {
			if (0.9 * Screen.height < Input.mousePosition.y && Input.mousePosition.y <= Screen.height) {
				return;
			}
			if (0.9 * Screen.width < Input.mousePosition.x && Input.mousePosition.x <= Screen.width) {
				return;
			}
			debugVector = GetDebugVector ();
		}
	}

	private Vector3 GetDebugVector ()
	{
		Vector3 mousePos = Input.mousePosition + Vector3.back * camera_obj.GetComponent<Camera> ().transform.position.z;
		Vector3 pos = Camera.main.ScreenToWorldPoint (mousePos);
		gameObject.transform.position = pos;
		return (gameObject.transform.position - player.transform.position).normalized;
	}
}
