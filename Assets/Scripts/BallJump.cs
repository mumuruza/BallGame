using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallJump : MonoBehaviour
{
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private float jumpForce = 5;
    [SerializeField] private GroundCheck groundCheck;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (groundCheck.IsGrounded())
                rigidbody.AddForce(Vector2.up * jumpForce);
        }
    }
}
