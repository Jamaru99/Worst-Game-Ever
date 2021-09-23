using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour {

	public TextMesh txtScore;
	public static ushort score = 0;
	float speed = 0.2f;
	public static float scale = 0.344f;

	void Start(){
		if (Player.secondChance) {
			score = 0;
			scale = 0.344f;
		}
		else {
			scale = PlayerPrefs.GetFloat ("LastScale");
			score = (ushort)PlayerPrefs.GetInt ("LastScore");
			txtScore.text = "" + score;
			transform.localScale = new Vector3(scale, 1.578085f, 1);
		}
	}

	void Update () {
		if (!Player.paused) {
			if (transform.position.y > -5.9f) {
				transform.position = new Vector2 (transform.position.x, transform.position.y - speed);
			} else {
				score += 1;
				txtScore.text = "" + score;
				transform.position = new Vector2 (Random.Range (-2.6f, 2.6f), 5.82f);
				transform.localScale = new Vector3(scale, 1.578085f, 1);
				speed += 0.002f;
				scale += 0.025f;
			}
		} 
	}


}
