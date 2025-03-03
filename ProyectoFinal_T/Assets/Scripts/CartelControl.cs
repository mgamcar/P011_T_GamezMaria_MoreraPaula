using UnityEngine;

public class CartelControl : MonoBehaviour
{
    [SerializeField] GameObject cartel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D other){
        if (other.gameObject.tag == "Player"){
            cartel.SetActive(true);
        }
    }

    void OnTriggerExit2D (Collider2D other){
        if (other.gameObject.tag == "Player"){
            cartel.SetActive(false);
        }
    }
}

