using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCheckpoint : MonoBehaviour
{
    [SerializeField] private FollowRiddle riddle = default;
    [SerializeField] private int id = 0;
    private bool isActivated = false;

    private void OnTriggerEnter(Collider collider)
    {
        if (!isActivated)
            riddle.Activate(id);
    }

    public void Activate()
    {
        if (isActivated)
            return;
        isActivated = true;
    }
}
