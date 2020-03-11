using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Responsible for world interactions, such as grabbing objects
public class Player : MonoBehaviour
{
    [SerializeField] private Transform camTransform = default;
    [SerializeField] private LayerMask itemLayer = default;
    [SerializeField] private float range = 1f;
    [SerializeField] private float grabPointDistance = 1f;

    private bool hasCaught = false;
    private Transform caughtObject = null;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!hasCaught)
                hasCaught = Grab();
        }
        if (Input.GetButtonUp("Fire1"))
            Release();
        if (Input.GetButtonDown("Interact"))
        {
            if (Interact())
                StartCoroutine(ResetInteractCD());
        }
    }

    private void LateUpdate()
    {
        if (caughtObject == null)
            return;

        caughtObject.position = camTransform.position + camTransform.forward * grabPointDistance;
    }

    private bool Grab()
    {
        if (Physics.Raycast(camTransform.position, camTransform.forward, out RaycastHit info, range, itemLayer))
        {
            caughtObject = info.transform;
            if (caughtObject.TryGetComponent(out Rigidbody rb))
                rb.isKinematic = true;
            return true;
        }
        return false;
    }
    private bool Interact()
    {
        if (Physics.Raycast(camTransform.position, camTransform.forward, out RaycastHit info, range, itemLayer))
        {
            if (info.transform.TryGetComponent(out Interactable interactable))
            {
                interactable.Interact();
                return true;
            }
        }
        return false;
    }

    private void Release()
    {
        if (caughtObject == null)
            return;
        if (caughtObject.TryGetComponent(out Rigidbody rb))
            rb.isKinematic = false;
        caughtObject = null;
        hasCaught = false;
    }

    private IEnumerator ResetInteractCD()
    {
        yield return new WaitForSecondsRealtime(1f);
    }
}
