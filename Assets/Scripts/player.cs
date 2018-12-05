using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class player : MonoBehaviour {

	public float forcaPulo;
	public float velocidadeMaxima;

	public bool nochao;

	public int vidas;
	public bool invunerable = false;
	public bool isAlive = true;
	public int radiacao;

	public Text Textlives;
	public Text TextRad;

	private SpriteRenderer sprite;

	void Awake(){
		sprite = GetComponent<SpriteRenderer> ();
		//player = GameObject.Find ("player").GetComponent<player> ();
	}

	void Start () 
	{
		Textlives.text = vidas.ToString();
		TextRad.text = radiacao.ToString();
	}
	
	// Update is called once per frame
	void Update () {

		if (isAlive) {
			
			Rigidbody2D rigidbody = GetComponent<Rigidbody2D> ();

			float movimento = Input.GetAxis ("Horizontal");
			float movimentoabaixa = Input.GetAxis ("Vertical");

			rigidbody.velocity = new Vector2 (movimento * velocidadeMaxima, rigidbody.velocity.y);

			if (movimento < 0) {
				GetComponent<SpriteRenderer> ().flipX = true;

			} else if (movimento > 0) {
				GetComponent<SpriteRenderer> ().flipX = false;

			}
		
			if (movimentoabaixa < 0) {
				GetComponent<Animator> ().SetBool ("down", true);
			} else {
				GetComponent<Animator> ().SetBool ("down", false);
			}


			if (movimento > 0 || movimento < 0) {
				GetComponent<Animator> ().SetBool ("walk", true);
			} else {
				GetComponent<Animator> ().SetBool ("walk", false);
			}
		

			if (Input.GetKeyDown (KeyCode.Space) && nochao) {
				rigidbody.AddForce (new Vector2 (0, forcaPulo));
				GetComponent<AudioSource> ().Play ();
			}

			if (nochao) {
				GetComponent<Animator> ().SetBool ("pulo", false);
			} else {
				GetComponent<Animator> ().SetBool ("pulo", true);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision2D){
		if(collision2D.gameObject.CompareTag("plataformas")){
			nochao = true;
		}

		//Debug.Log("Colidiu!"+collision2D.gameObject.tag);
	}

	void OnCollisionExit2D(Collision2D collision2D){
		if(collision2D.gameObject.CompareTag("plataformas")){
			nochao = false;
		}
	}

	IEnumerator Damage(){

		for ( float i = 0f; i < 1f; i += 0.1f) {
			sprite.enabled = false;
			yield return new WaitForSeconds (0.1f);
			sprite.enabled = true;
			yield return new WaitForSeconds (0.1f);
		}

		invunerable = false;
	}

	public void DamagePlayer(){

		if (isAlive) {
			invunerable = true;
			vidas--;
			Textlives.text = vidas.ToString ();
			StartCoroutine (Damage ());

			if (vidas < 1) {
				isAlive = false;
				GetComponent<Animator> ().SetTrigger ("morto");
				Invoke ("ReloadLevel", 3f);
			}
		}
	}

	void ReloadLevel(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}