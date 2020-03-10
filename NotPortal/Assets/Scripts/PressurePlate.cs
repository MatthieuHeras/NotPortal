using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool isActivated;
    [SerializeField] private Animator anim;
    private int numberOfObjectsOn = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Ground"))
        {
            numberOfObjectsOn++;
            if (numberOfObjectsOn == 1)
            {
                anim.SetTrigger("Activate");
                isActivated = true;
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (!collision.collider.CompareTag("Ground"))
        {
            numberOfObjectsOn--;
            if (numberOfObjectsOn == 0)
            {
                anim.SetTrigger("Deactivate");
                isActivated = false;
            }
        }
    }
}
