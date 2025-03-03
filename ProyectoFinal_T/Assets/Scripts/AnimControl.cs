using UnityEngine;

public class animControl : MonoBehaviour
{
    public void endShoot()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("isShooting", false);
    }
}
