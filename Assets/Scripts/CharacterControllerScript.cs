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
	 private bool isFacingRight = true;
    //ссылка на компонент анимаций
    private Animator anim;

	public float maxSpeed = 10f;

	void Start(){
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	void FixedUpdate(){
			float move = Input.GetAxis("Horizontal");

        //в компоненте анимаций изменяем значение параметра Speed на значение оси Х.
        //приэтом нам нужен модуль значения
        anim.SetFloat("Speed", Mathf.Abs(move));

		GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

		if(move > 0 && !isFacingRight)
            //отражаем персонажа вправо
            Flip();
        //обратная ситуация. отражаем персонажа влево
        else if (move < 0 && isFacingRight)
            Flip();
	}

	public void Move(int InputAxis){
		moveInput = Input.GetAxis;
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
			} else {
				isJumping = false;
			}
		}

	}
	public void jump3(){
			isJumping = false;
	} 

	private void Flip()
    {
        //меняем направление движения персонажа
        isFacingRight = !isFacingRight;
        //получаем размеры персонажа
        Vector3 theScale = transform.localScale;
        //зеркально отражаем персонажа по оси Х
        theScale.x *= -1;
        //задаем новый размер персонажа, равный старому, но зеркально отраженный
        transform.localScale = theScale;
    }

}
