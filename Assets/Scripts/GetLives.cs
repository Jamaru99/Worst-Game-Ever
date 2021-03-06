using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class GetLives : MonoBehaviour {

	RewardBasedVideoAd rbva;
	string adId = "ca-app-pub-1541045839364233/4008767279";

	void Start(){
		rbva = RewardBasedVideoAd.Instance;
		rbva.OnAdRewarded += HandleRewardBasedVideoRewarded;
		rbva.OnAdClosed += HandleAdClosed;
	
		AdRequest request = new AdRequest.Builder ().Build ();
		rbva.LoadAd (request, adId);
	}

	public void HandleAdClosed(object sender, EventArgs args){
		AdRequest request = new AdRequest.Builder ().Build ();
		rbva.LoadAd (request, adId);
	}

	public void HandleRewardBasedVideoRewarded(object sender, Reward args){
		Player.secondChance = false;
		Player.paused = false;
		SceneManager.LoadScene ("Game");
	}

	void Update(){
		if (Player.paused && Player.secondChance) {
			GetComponent<MeshRenderer> ().enabled = true;
			GetComponent<BoxCollider> ().enabled = true;
		}
	}

	void OnMouseDown(){
		transform.localScale *= 0.9f;
	}

	void OnMouseUp(){
		if (rbva.IsLoaded ()) 
			rbva.Show ();
		transform.localScale /= 0.9f;
	}


}
