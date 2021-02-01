using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LunchMenu : MonoBehaviour {

	public static int StageNumber = 12;

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			SceneManager.LoadScene (StageNumber);
		}
	}
}
