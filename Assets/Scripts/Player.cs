using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using GoogleMobileAds;
//using GoogleMobileAds.Api;

public class Player : MonoBehaviour {

	AudioSource audio;
	public AudioClip fun;
	public AudioClip crash;
	public static float speed = 0.04f;
	public static bool paused = false;
	public static bool secondChance = false;

	public GameObject gameOverObj1pt;
	public GameObject gameOverObj2pt;
	public GameObject gameOverObj1en;
	public GameObject gameOverObj2en;

	void Start(){
		audio = GetComponent<AudioSource> ();
	}

	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Bar.score = 0;
			SceneManager.LoadScene (0);
		}
		if (!paused) {
			if (Input.GetTouch (0).phase == TouchPhase.Moved) {
				Vector2 touchDelta = Input.GetTouch (0).deltaPosition;
				transform.Translate (touchDelta.x * speed, 0, 0);
			}
			Vector2 pos = new Vector2 (transform.position.x, transform.position.y);
			if (pos.x > 2.6f) transform.position = new Vector2 (2.5f, transform.position.y);
			if (pos.x < -2.6f) transform.position = new Vector2 (-2.5f, transform.position.y);

		} else {
			Invoke ("switchAudio", 0.8f);
		}
	}

	void OnTriggerEnter(Collider other){
		audio.Stop ();
		audio.clip = crash;
		audio.Play ();
		paused = true;
		if (Menu.pt) {
			if (secondChance) {
				gameOverObj1pt.SetActive (true);
				GameObject.Find ("btnVideo").GetComponentInChildren<TextMesh> ().text = "assistir";
			} else
				gameOverObj2pt.SetActive (true);
		} else {
			if (secondChance) {
				gameOverObj1en.SetActive (true);
				GameObject.Find ("btnVideo").GetComponentInChildren<TextMesh> ().text = "watch";
			} else
				gameOverObj2en.SetActive (true);
		}
		PlayerPrefs.SetInt ("LastScore", Bar.score);
		PlayerPrefs.SetFloat ("LastScale", Bar.scale);
		GooglePlayGame.ReportScore ("CgkIkP301eQEEAIQAA", Bar.score, (bool success) => {});
		if (PlayerPrefs.HasKey ("record")) {
			if (Bar.score > PlayerPrefs.GetInt ("record")) {
				PlayerPrefs.SetInt ("record", Bar.score);
			} 
		} else {
			PlayerPrefs.SetInt ("record", Bar.score);
		}
	}

	void switchAudio(){
		audio.Stop ();
		audio.clip = fun;
		audio.Play ();
	}

}
