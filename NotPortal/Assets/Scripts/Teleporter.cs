using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private LevelLoader levelLoader = default;

    private void OnTriggerEnter(Collider other)
    {
        levelLoader.Win();
    }
}
