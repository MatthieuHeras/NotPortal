using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private Animator anim = default;
    [SerializeField] private PressurePlateRiddle riddle = default;
    [SerializeField] private AudioSource sound = default;
    [SerializeField] private int id = 0;

    private bool isActivated = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!isActivated && collision.GetContact(0).normal == Vector3.down) // Land on it
        {
            isActivated = true;
            anim.SetTrigger("Activate");
            riddle.Activate(id);
            sound.Play();
        }
    }

    public void Deactivate()
    {
        if (!isActivated)
            return;
        isActivated = false;
        anim.SetTrigger("Deactivate");
    }           
}
