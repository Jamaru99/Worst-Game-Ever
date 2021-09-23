using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Recomecar : MonoBehaviour {

	void OnMouseDown(){
		transform.localScale *= 0.9f;
	}

	void OnMouseUp(){
		SceneManager.LoadScene ("Game");
		Player.paused = false;
		Player.secondChance = true;
	}
}
