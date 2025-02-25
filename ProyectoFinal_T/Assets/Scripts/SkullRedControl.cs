using UnityEngine;

public class SkullRedControl : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed;
    private int currentWaypoint;
    

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
    }


}
