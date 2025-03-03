using System;
using UnityEngine;

public class PlayerAnimControl : MonoBehaviour
{
    [SerializeField] Animator anim;

    [SerializeField] SpriteRenderer sprite;
    Rigidbody2D rb;

    [Header("Correr")]
    public int speed = 6;

    [Header("Saltar")]
    public int jump = 10;

    //Sprite Derecha-Izquierda
    public static bool right = true;

    [Header("Pegar Derecha-Izquierda")]
    [SerializeField] GameObject WeaponRight;
    [SerializeField] GameObject WeaponLeft;
    public static bool Daño = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Tipo de movimiento
        float inputX = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(inputX * speed, rb.linearVelocity.y);

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
        if (Input.GetMouseButtonDown(0)){
            anim.SetBool("isQAtacking", true);
            
            if (right == true){
               WeaponRight.SetActive(true);
               Daño = true;
            } else {
                WeaponLeft.SetActive(true);
                Daño = true;
            }

        }
        if (Input.GetMouseButtonUp(0)){
            anim.SetBool("isQAtacking", false);
            WeaponRight.SetActive(false);
            WeaponLeft.SetActive(false);
            Daño = false;

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
}
