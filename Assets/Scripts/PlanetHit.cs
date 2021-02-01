using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

//ガス惑星などのお邪魔な自分自身のクラス実装
public class PlanetHit : MonoBehaviour
{

	public int HitType;


	void Start ()
	{
	}

	void OnCollisionEnter (Collision other)
	{//Playerタグでなければ、そのままスルー。Playerタグ以外はlostクラスへ
		if (!"Player".Equals (other.gameObject.tag)) {
			return;
		}
		lost (other.gameObject);
	}
		
	private void lost (GameObject player)
	{//ガス惑星（じしん）の衝突制御
		switch (HitType) {
		case 0:
			PlanetManager.Clear ();

			return;
		case 1:
			player.SetActive (false);
			this.gameObject.SetActive (false);
			PlanetManager.Over ();
			return;
		default :
			return;
		}

	}

}
