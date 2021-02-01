using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetManager : MonoBehaviour
{
	public AudioClip soundEffect_clear;
	private AudioSource	audioSource;

	private static int state;
	private float time = 0;
	public float MARGE_TIME = 1;

	public static int TYPE_BEFORE_THROW = 0;
	public static int TYPE_THROW = 1;
	public static int TYPE_AFTER_THROW = 2;
	public static int TYPE_GAMEOVER = 3;
	public static int TYPE_GAMECLEAR = 4;
	public static int TYPE_GAMECLEAR_MOVE = 5;

	public bool isDebug = false;

	// Use this for initialization
	void Start ()
	{
		state = TYPE_BEFORE_THROW;
		DebugInput.isDebug = isDebug;
		DebugForce.isDebug = isDebug;
		audioSource = gameObject.GetComponent<AudioSource> ();

		GameObject[] gos = GameObject.FindGameObjectsWithTag ("Debug");
		foreach (GameObject o in gos) {
			o.SetActive (isDebug);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (state == TYPE_BEFORE_THROW) {
			NextState ();
		} else if (state == TYPE_AFTER_THROW) {
		} else if (state == TYPE_GAMEOVER) {
		} else if (state == TYPE_GAMECLEAR) {
			if (time == 0) {
				time = Time.time;
				audioSource.clip = soundEffect_clear;
				audioSource.Play ();
			} else if (Time.time - time > MARGE_TIME) {
				state = TYPE_GAMECLEAR_MOVE;
			}
		} else if (state == TYPE_GAMECLEAR_MOVE) {
			//Countup Stage
			LevelManager.Next ();
		}
	}

	public static void NextState ()
	{
		state++;
	}

	public static int GetState ()
	{
		return state;
	}

	public static void Clear ()
	{
		if (state == TYPE_AFTER_THROW) {
			state = TYPE_GAMECLEAR;
		}
	}

	public static void Over ()
	{
		if (state == TYPE_AFTER_THROW) {
			LevelManager.Reset ();
		}
	}

}
