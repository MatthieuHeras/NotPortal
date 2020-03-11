using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButton : Interactable
{
    [SerializeField] private AudioSource sound = default;

    public override void Interact()
    {
        sound.Play();
        Debug.Log("play");
    }
}
