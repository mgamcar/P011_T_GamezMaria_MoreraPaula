using System;
using UnityEngine;
using UnityEngine.UI;

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
    public static bool QAtack = false;

    [Header("Pegar Derecha-Izquierda")]
    [SerializeField] GameObject WeaponRight;
    [SerializeField] GameObject WeaponLeft;


    [Header("Vida")]
    [SerializeField] Slider PlayerBar;
    [SerializeField] float health = 100;
    [SerializeField] float dps = 30;
    [SerializeField] int items = 0;
    bool Dead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Es lo mismo que meter todo en el if de seimrpre ese raro de Paco de Dead == true y no hace nada
        if (Dead == true){
            return;
        }

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
            QAtack = true;

            if (right == true){
                WeaponRight.SetActive(true);

            } else {
                WeaponLeft.SetActive(true);

            }
        }
        if (Input.GetMouseButtonUp(0)){
            anim.SetBool("isQAtacking", false);
            QAtack = false;
            WeaponRight.SetActive(false);
            WeaponLeft.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }    
        
    }

    

    public void Daño(){
        health = health - dps;
        PlayerBar.value = health;
        anim.SetBool("isHit", true);
        Invoke ("HasBeenHit", 0.5f);

        if (health <= 0 && Dead == false){
            anim.SetTrigger("hasDied");
            Dead = true;
        }
    }

    void HasBeenHit(){
        anim.SetBool("isHit", false);
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

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Item")
        {
            Destroy(other.gameObject);
            health = health + dps;
            PlayerBar.value = health;

        }
    }

    

}
