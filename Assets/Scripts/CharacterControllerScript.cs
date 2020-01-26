using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour {

	private Rigidbody2D rb;
	public float speed;
	public float jumpForce;
	private float moveInput;
	public int directionInput;

	private bool isGrounded;
	public Transform feetPos;
	public float checkRadius;
	public LayerMask whatIsGround;

	private float jumpTimeCounter;
	public float jumpTime;
	public bool isJumping;

	void Start(){
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate(){
		rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
	}

	public void Move(int InputAxis){
		moveInput = InputAxis;
	}

	public void jump(){
		isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
		if(isGrounded == true){
			isJumping = true;
			jumpTimeCounter = jumpTime;
			rb.velocity = Vector2.up * jumpForce;
			if(jumpTimeCounter > 0){
				rb.velocity = Vector2.up * jumpForce;
				jumpTimeCounter -= Time.deltaTime;
			}
		}

	}
	public void jump3(){
			isJumping = false;
	} 

}
