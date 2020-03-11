using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riddle : MonoBehaviour
{
    [SerializeField] private Door outDoor = default;

    protected bool isSolved = false;

    protected virtual void Win()
    {
        isSolved = true;
        Debug.Log("Riddle solved !");
        outDoor.Open();
    }
}
