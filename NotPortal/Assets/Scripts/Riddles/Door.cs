using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public void Open()
    {
        GetComponent<Animator>().SetBool("isOpen", true);
        GetComponent<AudioSource>().Play();
        Debug.Log("Door opens !");
    }
}
