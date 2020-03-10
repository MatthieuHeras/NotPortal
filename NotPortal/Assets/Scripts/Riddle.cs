using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riddle : MonoBehaviour
{
    [SerializeField] private Door outDoor;

    protected bool isResolved = false;
    protected bool isEnded = false;

    protected void Win()
    {
        Debug.Log("Riddle solved !");
        outDoor.Open();
    }

    protected virtual void Update()
    {
        if (isResolved)
        {
            Win();
            isEnded = true;
        }
    }
}
