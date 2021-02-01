using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelManager
{
	public static int NowStage = 0;

	public static void Next ()
	{
		NowStage++;
		if (NowStage < SceneManager.sceneCountInBuildSettings) {	
			load (NowStage);
		} else {
			Reset ();
		}
	}

	public static void Reset ()
	{
		NowStage = 0;
		load (NowStage);
	}

	private static void load (int stage)
	{
		SceneManager.LoadScene (stage);
	}

}
