using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranking : MonoBehaviour {

	void OnMouseDown(){
		transform.localScale *= 0.9f;
	}

	void OnMouseUp(){
		GooglePlayGame.ShowLeadboards ();
		transform.localScale /= 0.9f;
	}

}
