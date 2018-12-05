using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject PainelCompleto;

	public bool emPausa = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void pause(){
		if (emPausa) {
			PainelCompleto.SetActive (false);
			emPausa = false;
		} else {
			PainelCompleto.SetActive (true);
			emPausa = true;
		}
	}

	public void sair(){
		SceneManager.LoadScene ("inicio");
	}

}
