using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds;
using GoogleMobileAds.Api;
//using GooglePlayGames;
//using UnityEngine.SocialPlatforms;
//using GooglePlayGames.BasicApi;

public class Menu : MonoBehaviour {

	public TextMesh record;
	public TextMesh title;
	BannerView banner;
	public static bool pt;

	void Start () {
		pt  = Application.systemLanguage == SystemLanguage.Portuguese;
		if (pt) {
			record.text = "Recorde: " + PlayerPrefs.GetInt ("record");
			title.text = "Pior Jogo do Mundo";
		} else {
			record.text = "Best Score: " + PlayerPrefs.GetInt ("record");
		} 
		banner = new BannerView ("ca-app-pub-1541045839364233/8182981856", AdSize.Banner, AdPosition.Top);
		banner.LoadAd (new AdRequest.Builder ().Build ());
		banner.Show ();
		GooglePlayGame.Init ();
		GooglePlayGame.Login((bool success) => {});
	}

	void OnMouseDown(){
		Player.paused = false;
		Player.secondChance = true;
		transform.localScale *= 0.9f;
		SceneManager.LoadScene (1);
	}
		
}
