
using UnityEngine;

public class SkullRed_Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform player;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindObjectOfType<PlayerAnimControl>().transform;
        rb = GetComponent <Rigidbody2D>();
        LaunchProjectile();

        Invoke("destroyShot",4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LaunchProjectile()
    {
        Vector2 directionToPlayer = (player.position - transform.position).normalized;
        rb.linearVelocity = directionToPlayer * speed;
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
            //other.gameObject.GetComponent<FinalEnemyControl>().vidaMenos();
            destroyShot();
        }
    }

    void destroyShot(){
        Destroy(gameObject);
    }

}