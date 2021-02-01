using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour {

	void Start () {
		// コルーチンを実行  
		StartCoroutine ("NextJob");  
	}  

	// コルーチン  
	private IEnumerator NextJob() {  

		yield return new WaitForSeconds (2.0f);  

		// コルーチンの処理  
		SceneManager.LoadScene (2);

	}  

}
