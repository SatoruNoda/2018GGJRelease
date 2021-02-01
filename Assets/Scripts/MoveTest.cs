using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTest : MonoBehaviour
{

	public GameObject image;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GetComponent<InputHelper> ().isPush) {
			changeImage ();
		} else {
			changeImage2 ();
		}
		if (GetComponent<InputHelper> ().time > 0) {
			Debug.Log ("OK");
			changeImage3 ();
		}
	}

	public void changeImage ()
	{
		image.GetComponent<Image> ().color = new Color (1.0f, 0.0f, 0.0f);
	}

	public void changeImage2 ()
	{
		image.GetComponent<Image> ().color = new Color (0.0f, 1.0f, 0.0f);
	}

	public void changeImage3 ()
	{
		image.GetComponent<Image> ().color = new Color (0.0f, 0.0f, 1.0f);
	}
}
