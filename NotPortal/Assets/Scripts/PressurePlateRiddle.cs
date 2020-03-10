using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateRiddle : Riddle
{
    [SerializeField] private List<PressurePlate> pressurePlates = new List<PressurePlate>();

    
    protected override void Update()
    {
        if (isEnded)
            return;

        isResolved = true;
        foreach (PressurePlate PP in pressurePlates)
            if (!PP.isActivated)
                isResolved = false;

        base.Update();
    }
}
