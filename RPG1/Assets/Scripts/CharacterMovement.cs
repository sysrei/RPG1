using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

	private Rigidbody2D playerRigidbody2D;
	private bool facingRight;
	public float speed = 4.0f;
	private Animator animator;
	private GameObject playerSprite;
	
	void Awake(){
		playerRigidbody2D = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));
		playerSprite = transform.Find("Player").gameObject;
		animator = (Animator)playerSprite.GetComponent(typeof(Animator));
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float movePlayerVector = Input.GetAxis("Horizontal");
		playerRigidbody2D.velocity = new Vector2(movePlayerVector * speed, playerRigidbody2D.velocity.y);
		animator.SetFloat("speed", Mathf.Abs(movePlayerVector));
		if(movePlayerVector < 0 && !facingRight){
			Flip();
		}
		else if(movePlayerVector > 0 && facingRight){
			Flip();
		}
	}

	void Flip(){
		facingRight = !facingRight;

		//Multiply the player's x local scale by -1.
		Vector3 theScale = playerSprite.transform.localScale;
		theScale.x *= -1;
		playerSprite.transform.localScale = theScale;

	}


}
