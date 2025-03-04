using UnityEngine;


public class EnemyBatControl : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed;
    private int currentWaypoint;

    [SerializeField] SpriteRenderer sprite;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != waypoints[currentWaypoint].position){
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);
       }
       else {
            currentWaypoint ++;
            if (currentWaypoint == waypoints.Length){
                currentWaypoint = 0;
            }
       }

        Flip();
       
    }

    void Flip(){
        if (transform.position.x > waypoints[currentWaypoint].position.x)
        {
            sprite.flipX = true;
        } else{
            sprite.flipX = false;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerAnimControl>().Daño();
        }
        if (other.gameObject.tag == "PlayerArma"){
            Destroy (gameObject);
        }

    }

}