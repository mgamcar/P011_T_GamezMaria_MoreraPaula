using UnityEngine;

public class TeleportsControl1 : MonoBehaviour
{
    [SerializeField] GameObject TxtTP;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            TxtTP.SetActive(true);
            Cursor.visible = true;
        }
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            TxtTP.SetActive(false);
            Cursor.visible = false;
        }
        
    }
}
