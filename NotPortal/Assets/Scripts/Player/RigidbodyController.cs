using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyController : MonoBehaviour
{
    [SerializeField] private float speed = 50f;
    [SerializeField] private float movementDrag = 8f;
    [SerializeField] private float jumpForce = 20f;
    [SerializeField] private int jumpLimit = 1;
    [SerializeField] private Transform camTransform = default;
    [SerializeField] private Transform feet = default;
    [SerializeField] private LayerMask groundLayer = default;

    [Range(0, 2)]
    [SerializeField] private float jumpModifier1 = 0.5f;
    [Range(0, 2)]
    [SerializeField] private float jumpModifier2 = 0.5f;
    [Range(0, 1)]
    [SerializeField] private float keepPressJump = 0.5f;

    private Rigidbody rb;
    private Transform playerTransform;
    private AudioSource stepSound;
    private int jumpBuffer = 0;
    private bool isJumping = false;
    private bool isGrounded = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerTransform = GetComponent<Transform>();
        stepSound = GetComponent<AudioSource>();

        if (rb == null || stepSound == null)
            Debug.LogError("Component missing on : " + name);
    }

    private void FixedUpdate()
    {
        // Large jumps
        if (Input.GetButton("Jump") && Vector3.Dot(rb.velocity, Physics.gravity) < 0f)
            rb.AddForce(-Physics.gravity * keepPressJump, ForceMode.Acceleration);

        if (rb.velocity.y > 0)
            rb.AddForce(jumpModifier1 * Physics.gravity);
        if (rb.velocity.y < 0)
            rb.AddForce(jumpModifier2 * Physics.gravity);
    }

    private void Update()
    {
        // Controls
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        // Move
        rb.velocity = speed * xAxis * playerTransform.right + rb.velocity.y * Vector3.up + speed * yAxis * playerTransform.forward;


        stepSound.pitch = (isGrounded) ? Mathf.Sqrt(xAxis * xAxis + yAxis * yAxis) : 0f;
        
        if (!isJumping)
        {
            if (Physics.OverlapSphere(feet.position, 0.3f, groundLayer).Length > 0)
                TouchGround();
            else if (isGrounded)
                LeaveGround();
        }
        // Jump
        if (Input.GetButtonDown("Jump") && !isJumping && jumpBuffer < jumpLimit)
            Jump();
    }

    public void Teleport(Vector3 point)
    {
        playerTransform.position = point;
    }

    private void Jump()
    {
        jumpBuffer++;
        isJumping = true;
        isGrounded = false;
        StartCoroutine(nameof(ResetIsJumping)); // Avoid spamming

        Vector3 localVelocity = playerTransform.InverseTransformDirection(rb.velocity); // Convert to local space
        if (localVelocity.y < jumpForce)
            localVelocity = new Vector3(localVelocity.x, jumpForce, localVelocity.z); // Use velocity instead of force, better for gameplay
        rb.velocity = playerTransform.TransformDirection(localVelocity);
    }

    private void TouchGround()
    {
        StopCoroutine(LoseGroundCoroutine());
        jumpBuffer = 0;
        isGrounded = true;
    }
    private void LeaveGround()
    {
        StartCoroutine(LoseGroundCoroutine());
    }

    private IEnumerator ResetIsJumping()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        isJumping = false;
    }
    private IEnumerator LoseGroundCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        jumpBuffer++;
        isGrounded = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(feet.position, 0.3f);
    }
}
