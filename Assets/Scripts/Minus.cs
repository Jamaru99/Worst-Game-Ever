using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minus : MonoBehaviour {

	public TextMesh s;

	void OnMouseDown(){
		Player.speed -= 0.02f;
		s.text = Plus.i + Player.speed * 100;
	}
}
