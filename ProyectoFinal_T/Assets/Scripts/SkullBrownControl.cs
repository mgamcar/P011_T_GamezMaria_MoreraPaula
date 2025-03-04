using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkullBrownControl : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed;
    private int currentWaypoint;

    [SerializeField] private GameObject RedSkull_Projectile;
    [SerializeField] private float timeBetweenShoots;

    bool FaseON1 = true;
    bool FaseON2 = false;
    bool Dentro = false;
    private Coroutine fase1Coroutine;
    private Coroutine fase2Coroutine;

    private BossFight1 Barra;

    [Header("Vida")]
    [SerializeField] Slider BossBar;
    [SerializeField] float health = 100;
    [SerializeField] float dps = 30;
    
    void Awake(){
        Barra = GameObject.Find("Boss1").GetComponent<BossFight1>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (FaseON1)
        {
            fase1Coroutine = StartCoroutine(Fase1());
        }
        else if (FaseON2)
        {
            fase2Coroutine = StartCoroutine(Fase2());
        }
        
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

        // Cambiar de fase cuando la salud llegue a 50 o menos
        if (health <= 50 && !FaseON2)
        {
            FaseON1 = false;  // Desactivar Fase1
            FaseON2 = true;   // Activar Fase2

            // Detener la Fase1 y comenzar Fase2
            if (fase1Coroutine != null)
            {
                StopCoroutine(fase1Coroutine);  // Detener la corutina de Fase1
            }
            fase2Coroutine = StartCoroutine(Fase2());  // Iniciar Fase2
        }

        if (health <= 0){
            Barra.Barra();
            Destroy(gameObject);
        }

       

    }

    //Daño
    void OnTriggerEnter2D (Collider2D other){
        if (other.gameObject.tag == "PlayerArma"){
            Dentro = true;
            if (Dentro == true && PlayerAnimControl.QAtack == true){
                health = health - dps * Time.deltaTime;
                BossBar.value = health;    
            }
        }

    }

    void OnTriggerExit2D (Collider2D other){
        if (other.gameObject.tag == "PlayerArma"){
            Dentro = false;
        }
    }

    IEnumerator Fase1(){
        while (true){
            yield  return new WaitForSeconds(timeBetweenShoots);
            Instantiate (RedSkull_Projectile, transform.position, Quaternion.identity); 
        }
        
    }

    IEnumerator Fase2(){
        while (true){
            yield  return new WaitForSeconds(timeBetweenShoots);
            Instantiate (RedSkull_Projectile, transform.position, Quaternion.identity);

            Vector3 secondProjectilePosition = transform.position + new Vector3(1f, 1f, 0);
            Instantiate(RedSkull_Projectile, secondProjectilePosition, Quaternion.identity);

            Vector3 thirdProjectilePosition = transform.position + new Vector3(2f, 2f, 0);
            Instantiate(RedSkull_Projectile, thirdProjectilePosition, Quaternion.identity); 
        }
        
    }


}
