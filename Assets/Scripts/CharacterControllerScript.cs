using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterControllerScript : MonoBehaviour
{
    //находится ли персонаж на земле или в прыжке?
	private bool isGrounded = false;
	//ссылка на компонент Transform объекта
	//для определения соприкосновения с землей
	public Transform groundCheck;
	//радиус определения соприкосновения с землей
	private float groundRadius = 0.2f;
	//ссылка на слой, представляющий землю
	public LayerMask whatIsGround;
    //переменная для установки макс. скорости персонажа
    public float maxSpeed = 10f;
    public float jumpForce = 600;
    public float jumpForceExtra = 300;
    //переменная для определения направления персонажа вправо/влево
    private bool isFacingRight = true;
    //ссылка на компонент анимаций
    private Animator anim;


	private int extraJumps;
	public int extraJumpsValue;

    /// <summary>
    /// Начальная инициализация
    /// </summary>
	private void Start()
    {
	extraJumps = extraJumpsValue;
        anim = GetComponent<Animator>();
    }
	
    /// <summary>
    /// Выполняем действия в методе FixedUpdate, т. к. в компоненте Animator персонажа
    /// выставлено значение Animate Physics = true и анимация синхронизируется с расчетами физики
    /// </summary>
	private void FixedUpdate()
    {
		//определяем, на земле ли персонаж
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround); 
		//устанавливаем соответствующую переменную в аниматоре
		anim.SetBool ("Ground", isGrounded);
		//устанавливаем в аниматоре значение скорости взлета/падения
		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
        //если персонаж в прыжке - выход из метода, чтобы не выполнялись действия, связанные с бегом
        if (!isGrounded)
            return;
        //используем Input.GetAxis для оси Х. метод возвращает значение оси в пределах от -1 до 1.
        //при стандартных настройках проекта 
        //-1 возвращается при нажатии на клавиатуре стрелки влево (или клавиши А),
        //1 возвращается при нажатии на клавиатуре стрелки вправо (или клавиши D)
        float move = Input.GetAxis("Horizontal");

        //в компоненте анимаций изменяем значение параметра Speed на значение оси Х.
        //приэтом нам нужен модуль значения
        anim.SetFloat("Speed", Mathf.Abs(move));

        //обращаемся к компоненту персонажа RigidBody2D. задаем ему скорость по оси Х, 
        //равную значению оси Х умноженное на значение макс. скорости
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        //если нажали клавишу для перемещения вправо, а персонаж направлен влево
        if(move > 0 && !isFacingRight)
            //отражаем персонажа вправо
            Flip();
        //обратная ситуация. отражаем персонажа влево
        else if (move < 0 && isFacingRight)
            Flip();
    }

    /// <summary>
    /// Метод для смены направления движения персонажа и его зеркального отражения
    /// </summary>
	private void Update()
	{
		if (isGrounded == true)
		{
			extraJumps = extraJumpsValue;
		}
		//если персонаж на земле и нажат пробел...
		if (extraJumps > 0 && Input.GetKeyDown (KeyCode.Space)) 
		{
			//устанавливаем в аниматоре переменную в false
			anim.SetBool("Ground", false);
			//прикладываем силу вверх, чтобы персонаж подпрыгнул
            		GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
			extraJumps--;				
		} else if (extraJumps == 0 && Input.GetKeyDown (KeyCode.Space) && isGrounded == true)
				{
				GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForceExtra));		
				}
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
