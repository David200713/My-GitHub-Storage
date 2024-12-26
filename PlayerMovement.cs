using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveForce;
    public float jumpForce;
    [Space(5)]
    [Range(0f, 100f)] public float raycastDistance = 1.5f;
    public LayerMask whatIsGround;

    [Header("Camera Follow")]
    public Camera cam;
    [Range(0f, 1f)] public float interpolation 0.1f;
    public Vector3 offSet = new Vector3(0f, 2f, -10f);

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        Jump();
        CameraFollow();
    }

    private void Movement()
    {
        float xDir = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xDir * (moveForce * Time.deltaTime), rb.velocity.y);
    }

    private void Jump()
    {
        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            if(IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.deltaTime);
            }
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, whatIsGround);
        return hit.collider != null;
    }

    private void CameraFollow()
    {
        cam.transform.position = Vector3.Lerp(cam.transform.position, transform.position + offSet, interpolation);
    }
}
