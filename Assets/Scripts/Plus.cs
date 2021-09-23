using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plus : MonoBehaviour {

	public TextMesh s;
	public static string i;

	void Start(){
		
		i = Menu.pt?"Sensibilidade: ":"Sensitivity: ";
		s.text = i + Player.speed * 100;
	}

	void OnMouseDown(){
		Player.speed += 0.02f;
		s.text = i + Player.speed * 100;
	}
}
