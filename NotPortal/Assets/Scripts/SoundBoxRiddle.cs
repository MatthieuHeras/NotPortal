using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBoxRiddle : Riddle
{
    [SerializeField] private List<SoundBox> soundBoxes = new List<SoundBox>();

    protected override void Update()
    {
        if (isEnded)
            return;

        isResolved = true;
        foreach (SoundBox SB in soundBoxes)
            if (!SB.isActivated)
                isResolved = false;

        base.Update();
    }

}
