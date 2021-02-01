using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHelper : MonoBehaviour
{
	public float time = 0f;

	public float StartMin = 100f;
	public float StartMax = 500f;

	public bool isPush = false;
	private float mTime;
	private Vector3 mStartPos;
	private Vector3 mEndPos;

	public AudioClip soundEffect_clear;
	private AudioSource	audioSource;

	// Use this for initialization
	void Start ()
	{
		reset ();

	}
	
	// Update is called once per frame
	void Update ()
	{
		check ();
	}

	public Vector3 Get ()
	{
		if (DebugInput.isDebug) {
			return DebugInput.debugVector * Mathf.Lerp (StartMin, StartMax, DebugForce.force);
		}
		Vector3 result = (mEndPos - mStartPos) / time;
		result.x /= Screen.width;
		result.y /= Screen.height;
		result = result.normalized * Mathf.Lerp (StartMin, StartMax, result.magnitude / StartMax);
		return result;
	}

	public void check ()
	{
		if (DebugInput.isDebug) {
			if (DebugForce.isShoot) {
				time = 1;
			}
			return;
		}
		Vector3 mouse_pos = Input.mousePosition;
		if (Input.GetMouseButtonDown (0)) {
			start (mouse_pos);

		}
		if (Input.GetMouseButtonUp (0)) {
			end (mouse_pos);
			audioSource = GetComponent<AudioSource> ();
			audioSource.clip = soundEffect_clear;
			audioSource.Play ();
		}
	}

	private void reset ()
	{
		mStartPos = Vector3.zero;
		mEndPos = Vector3.zero;
		time = 0;
		isPush = false;
	}

	private void start (Vector3 mouse)
	{
		isPush = true;
		mTime = Time.time;
		mStartPos = mouse;
	}

	private void end (Vector3 mouse)
	{
		isPush = false;
		mEndPos = mouse;
		time = Time.time - mTime;
	}
}
