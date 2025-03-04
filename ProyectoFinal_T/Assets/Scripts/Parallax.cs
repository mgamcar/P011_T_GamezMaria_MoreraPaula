using UnityEngine;

public class parallaxEffect : MonoBehaviour
{
    [SerializeField] float effect;
    GameObject mainCamera;
    Vector3 lastCamPosition;

    void Start()
    {
        mainCamera = Camera.main.gameObject;
        lastCamPosition = mainCamera.transform.position;
    }

  
    void LateUpdate()
    {
        Vector3 cameraMovement = 
               mainCamera.transform.position  -
               lastCamPosition;

        transform.position += new Vector3(
               cameraMovement.x * effect,
               cameraMovement.y,
               0
        );      

        lastCamPosition = mainCamera.transform.position; 
    }
}

