using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform camTransform = default;
    [SerializeField] private Transform targetTransform = default;
    [SerializeField] private float mouseSensitivity = 50f;

    private float xCurrentRotation = 0f;
    private Vector2 targetRotation = Vector2.zero;

    void Update()
    {
        float xMouse = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float yMouse = -Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.right * yMouse);
        targetTransform.Rotate(targetTransform.up * xMouse);
    }
}
