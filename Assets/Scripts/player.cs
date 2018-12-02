using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class player : MonoBehaviour {

	public float forcaPulo;
	public float velocidadeMaxima;

	public bool nochao;

	public int vidas;
	public int radiacao;

	public Text Textlives;
	public Text TextRad;

	void Start () 
	{
		Textlives.text = vidas.ToString();
		TextRad.text = radiacao.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

		float movimento = Input.GetAxis("Horizontal");
		float movimentoabaixa = Input.GetAxis("Vertical");

		rigidbody.velocity = new Vector2(movimento*velocidadeMaxima,rigidbody.velocity.y);

		if (movimento < 0){
			GetComponent<SpriteRenderer>().flipX = true;

		}else if (movimento > 0){
			GetComponent<SpriteRenderer>().flipX = false;

		}
		
		if (movimentoabaixa < 0){
			GetComponent<Animator>().SetBool("down", true);
		}else{
			GetComponent<Animator>().SetBool("down", false);
		}


	 	if(movimento > 0 || movimento < 0){
			 GetComponent<Animator>().SetBool("walk", true);
		 }else{
			 GetComponent<Animator>().SetBool("walk", false);
		 }
		

		if (Input.GetKeyDown(KeyCode.Space) && nochao)
		{
			rigidbody.AddForce(new Vector2(0,forcaPulo));
			GetComponent<AudioSource>().Play();
		}

		if (nochao) {
			GetComponent<Animator>().SetBool ("pulo", false);
		} else {
			GetComponent<Animator>().SetBool ("pulo", true);
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

}