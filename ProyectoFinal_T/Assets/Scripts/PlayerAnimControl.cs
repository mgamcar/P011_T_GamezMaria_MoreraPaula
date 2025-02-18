using System;
using UnityEngine;

public class PlayerAnimControl : MonoBehaviour
{
    [SerializeField] Animator anim;

    [SerializeField] SpriteRenderer sprite;
    Rigidbody2D rb;

    //Muerte
    public bool endGame = false;

    [Header("Correr")]
    public int normalSpeed = 8;
    //Sprint tiempo
    public int sprintSpeed = 20;
    private float sprintDuration = 0.1f;
    private float sprintTimer = 0f;
    private float timeBetweenSprint = 4f;
    private float timeSinceSprint = 0;

    [Header("Saltar")]
    public int jump = 10;

    //Sprite Derecha-Izquierda
    public static bool right = true;

    //Ataque
    public static bool QAtack = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Muerte NO
        if (!endGame)
        {

            //Tipo de movimiento
            float inputX = Input.GetAxis("Horizontal");
            rb.linearVelocity = new Vector2(inputX * normalSpeed, rb.linearVelocity.y);

            if (inputX > 0)
            { //Derecha
                sprite.flipX = false;
                right = true;
            }
            else if (inputX < 0)
            {  //Izquierda
                sprite.flipX = true;
                right = false;
            }

            //Correr
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                anim.SetBool("isRunning", true);
            }
            else
            {
                anim.SetBool("isRunning", false);
            }

            //Sprint
            timeSinceSprint += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.LeftShift) && sprintTimer <= 0f && timeSinceSprint >= timeBetweenSprint)
            {
                normalSpeed = sprintSpeed;
                sprintTimer = sprintDuration;
                timeSinceSprint = 0f;
            }
            if (sprintTimer > 0f)
            {
                sprintTimer -= Time.deltaTime;
            }
            else
            {
                normalSpeed = 6;
            }


            //Salto
            if (Grounded() == false)
            {
                anim.SetBool("isJumping", true);
            }
            else
            {
                anim.SetBool("isJumping", false);
            }

            //Si está presionado el espacio y el tiempo de juego - la última vez que saltó es mayor que 1 (jumpCooldown) si puedes saltar
            if (Input.GetKeyDown(KeyCode.Space) && Grounded())
            {
                rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            }

            //QuickAtack
            if (Input.GetMouseButton(0))
            {
                anim.SetBool("isQAtacking", true);
                QAtack = true;


            }
            if (Input.GetMouseButtonUp(0))
            {
                anim.SetBool("isQAtacking", false);
                QAtack = false;
            }

            //SlowAtack
            if (Input.GetMouseButton(1))
            {
                anim.SetBool("isSAtacking", true);
                Invoke("SlowA", 1);
            }

            //Falling
            if (rb.linearVelocityY < 0)
            {
                anim.SetBool("isFalling", true);
            }
            else
            {
                anim.SetBool("isFalling", false);
            }


        }
        else
        {
            rb.linearVelocity = Vector2.zero;
            anim.SetTrigger("hasDied");

        }



    }

    //Comprobar si está en el suelo con verdadero-falso
    bool Grounded()
    {
        RaycastHit2D touch = Physics2D.Raycast(transform.position, Vector2.down, 0.2f);

        if (touch.collider == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }


    //SlowAtack
    void SlowA()
    {
        anim.SetBool("isSAtacking", false);
    }

}
