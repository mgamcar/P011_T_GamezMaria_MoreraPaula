using UnityEngine;

public class BossFight1 : MonoBehaviour
{
    [SerializeField] GameObject BossBar;

    void OnTriggerEnter2D (Collider2D other){
        if (other.gameObject.tag == "Player"){ 
            BossBar.SetActive(true);
        }

    }

    public void Barra(){
      BossBar.SetActive(false);  
    }
}
