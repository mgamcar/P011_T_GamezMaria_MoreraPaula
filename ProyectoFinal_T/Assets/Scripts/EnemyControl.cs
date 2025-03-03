using UnityEngine;


public class EnemyControl : MonoBehaviour
{
    [SerializeField] int speed = 3;
    [SerializeField] Vector3 endPosition;
    Vector3 startPosition;
    bool goingToTheEnd = true;

    [SerializeField] SpriteRenderer sprite;
    float previousXPos;

    float lives = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
        previousXPos = transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        if (goingToTheEnd)
        {
            transform.position = Vector3.MoveTowards(
                           transform.position,
                           endPosition,
                           speed * Time.deltaTime);
            if (transform.position == endPosition)
            {
                goingToTheEnd = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(
                           transform.position,
                           startPosition,
                           speed * Time.deltaTime);
            if (transform.position == startPosition)
            {
                goingToTheEnd = true;
            }
        }


        if (transform.position.x < previousXPos)
        {
            sprite.flipX = true;
        }
        else if (transform.position.x > previousXPos)
        {
            sprite.flipX = false;
        }

        previousXPos = transform.position.x;


        if (lives <= 0){
            Destroy (gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerAnimControl>().Daño();
        }
        if (other.gameObject.tag == "PlayerArma"){
            lives--;
        }

    }

}
