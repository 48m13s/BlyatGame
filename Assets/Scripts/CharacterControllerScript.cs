using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterControllerScript : MonoBehaviour
{
	private Rigidbody2D rb;
	private bool isGrounded = false;
	public Transform groundCheck;
	private float groundRadius = 0.2f;
	public LayerMask whatIsGround;
    public float maxSpeed = 10f;
    public float jumpForce = 600;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    private bool isFacingRight = true;
    private Animator anim;

	private int extraJumps;
	public int extraJumpsValue;

	private void Start()
    {
	extraJumps = extraJumpsValue;
        anim = GetComponent<Animator>();
	rb = GetComponent<Rigidbody2D>();
    }
	
	private void FixedUpdate()
    {
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround); 
		anim.SetBool ("Ground", isGrounded);
		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
        //if (!isGrounded)
            //return;
        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(move));

        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if(move > 0 && !isFacingRight)
            Flip();
        else if (move < 0 && isFacingRight)
            Flip();
    }

	private void Update()
	{
		if (isGrounded == true)
		{
			extraJumps = extraJumpsValue;
		}
		if (extraJumps > 0 && Input.GetKeyDown (KeyCode.Space)) 
		{
			isJumping = true;
			jumpTimeCounter = jumpTime;
			anim.SetBool("Ground", false);
            		rb.velocity = Vector2.up * jumpForce;
			extraJumps--;				
		} else if (extraJumps == 0 && Input.GetKeyDown (KeyCode.Space) && isGrounded == true)
				{
				rb.velocity = Vector2.up * jumpForce;		
				}
		if(Input.GetKey(KeyCode.Space)){
			
			if(jumpTimeCounter > 0){
				rb.velocity = Vector2.up * jumpForce;
				jumpTimeCounter -= Time.deltaTime;				
			} else {
				isJumping = false;			
			}
		}

		if(Input.GetKeyUp(KeyCode.Space)){
			isJumping = false;		
		}
	}
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
