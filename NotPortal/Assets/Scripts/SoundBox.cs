using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBox : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource = default;
    [SerializeField] private int id = 0;
    public bool isActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        SoundEmitter soundEmitter = other.GetComponent<SoundEmitter>();
        if (soundEmitter != null && soundEmitter.id == id)
        {
            isActivated = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        SoundEmitter soundEmitter = other.GetComponent<SoundEmitter>();
        if (soundEmitter != null && soundEmitter.id == id)
        {
            isActivated = false;
        }
    }
}
