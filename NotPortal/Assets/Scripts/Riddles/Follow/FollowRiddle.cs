using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRiddle : Riddle
{
    [SerializeField] private List<FollowCheckpoint> checkpoints = default;
    [SerializeField] List<Light> lights = default;
    [SerializeField] AudioSource lightSound = default;
    [SerializeField] Robot robot = default;
    private int currentID = 0;

    public void Activate(int checkpointID)
    {
        if (currentID == checkpointID)
        {
            checkpoints[currentID].Activate();
            if (currentID < checkpoints.Count - 1)
                robot.GoTo(checkpoints[currentID + 1].transform.position);
            currentID++;
        }
        if (currentID >= checkpoints.Count)
        {
            Win();
            return;
        }
    }

    protected override void Win()
    {
        foreach (Light l in lights)
            l.enabled = true;
        lightSound.Play();
        base.Win();
    }
}
