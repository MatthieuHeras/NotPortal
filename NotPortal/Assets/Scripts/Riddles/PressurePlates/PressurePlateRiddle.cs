using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateRiddle : Riddle
{
    [SerializeField] private List<PressurePlate> pressurePlates = new List<PressurePlate>();

    private int currentPressurePlate = 0;

    public void Activate(int id)
    {
        if (id != currentPressurePlate++)
            ResetRiddle();
        if (currentPressurePlate == pressurePlates.Count)
            Win();
    }

    private void ResetRiddle()
    {
        currentPressurePlate = 0;
        foreach (PressurePlate pp in pressurePlates)
            pp.Deactivate();
    }
}
