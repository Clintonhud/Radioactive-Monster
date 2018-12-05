using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTrigger : MonoBehaviour {

	private player player;
	// Use this for initialization
	void Awake(){
		player = GameObject.Find ("player").GetComponent<player> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("enemy")) {
			if (!player.invunerable) {
				player.DamagePlayer ();
			}
		}

		if (other.CompareTag ("Portal")) {
			Invoke ("NextLevel", 1f);
		}

	}

	void NextLevel(){
		SceneManager.LoadScene (SceneManager.GetActiveScene (). buildIndex + 1);
	}
}
