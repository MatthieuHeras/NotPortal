using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEmitter : Interactable
{
    [SerializeField] private AudioSource audioSource = default;
    public int id = 0;

    public override void Interact()
    {
        audioSource.Play();
    }
}
