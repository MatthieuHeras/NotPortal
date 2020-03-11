using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBoxRiddle : Riddle
{
    [SerializeField] private List<SoundBox> soundBoxes = new List<SoundBox>();

    protected void Update()
    {
        if (isSolved)
            return;

        isSolved = true;
        foreach (SoundBox SB in soundBoxes)
            if (!SB.isActivated)
                isSolved = false;
        if (isSolved)
            Win();
    }

}
