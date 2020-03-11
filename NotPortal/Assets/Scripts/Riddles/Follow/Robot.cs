using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField] private Transform robotTransform = default;
    [SerializeField] private Transform playerTransform = default;
    [SerializeField] private float speed = 5f;
    [Range(0, 10)]
    [SerializeField] private float rotationSpeed = 0.5f;
    [SerializeField] private AudioSource startSound = default;

    private Vector3 currentDestination;
    private bool hasReachedDestination = false;

    public void GoTo(Vector3 destination)
    {
        startSound.Play();
        currentDestination = destination;
        StopCoroutine(GoCoroutine());
        hasReachedDestination = false;
        StartCoroutine(GoCoroutine());
    }

    private IEnumerator GoCoroutine()
    {
        while(!hasReachedDestination)
        {
            robotTransform.position = Vector3.MoveTowards(robotTransform.position, currentDestination, speed * Time.deltaTime);
            if (robotTransform.position == currentDestination)
                hasReachedDestination = true;
            yield return null;
        }
    }

    private void LateUpdate()
    {
        robotTransform.rotation = Quaternion.Lerp(robotTransform.rotation, Quaternion.LookRotation(playerTransform.position - robotTransform.position), rotationSpeed * Time.deltaTime);
    }
}
