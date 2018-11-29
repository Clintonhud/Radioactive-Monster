using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class player : MonoBehaviour {

	public float forcaPulo;
	public float velocidadeMaxima;

	public int vidas;

	public Text Textlives;

	void Start () 
	{
		Textlives.text = vidas.ToString();
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
		

		if (Input.GetKeyDown(KeyCode.Space))
		{
			rigidbody.AddForce(new Vector2(0,forcaPulo));
		}
	}

	void OnCollisionEnter2D(Collision2D collision2D){
		Debug.Log("Colidiu!");
	}

	void OnCollisionExit2D(Collision2D collision2D){
		Debug.Log("Parou de colidir!");
	}

}