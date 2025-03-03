using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsMenu : MonoBehaviour
{
    [SerializeField] private GameObject ButtonStart;
    [SerializeField] private GameObject ButtonCredits;
    [SerializeField] private GameObject ButtonExit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(){
        ButtonStart.SetActive(false);
        SceneManager.LoadScene("Level1");
        
    }

    public void Credits(){
        ButtonCredits.SetActive(false);
        SceneManager.LoadScene("Credits");
        
    }

    public void ExitGame(){
        ButtonExit.SetActive(false);
        Application.Quit();
        
    }
}
