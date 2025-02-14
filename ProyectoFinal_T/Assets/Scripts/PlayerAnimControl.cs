using UnityEngine;

public class PlayerAnimControl : MonoBehaviour
{
    Animator anim;

    [SerializeField] SpriteRenderer sprite;

    //Salto
    [SerializeField] float jumpCooldown = 1;
    float lastJump = 0;

    //Sprite Derecha-Izquierda
    public static bool right = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Tipo de movimiento
        float movementX = Input.GetAxis("Horizontal");

        if (movementX > 0)
        { //Derecha
            sprite.flipX = false;
            right = true;
        }
        else if (movementX < 0)
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
            //Si está presionado el espacio y el tiempo de juego - la última vez que saltó es mayor que 1 (jumpCooldown) si puedes saltar
            if (Input.GetKeyDown(KeyCode.Space) && (Time.time - lastJump > jumpCooldown))
            {
                //La última vez que saltó = tiempo de juego
                lastJump = Time.time;
                anim.SetTrigger("hasJumped");
            }
        }


    }

    //Comprobar si está en el suelo con verdadero-falso
    bool Grounded()
    {
        RaycastHit2D touch = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);

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
