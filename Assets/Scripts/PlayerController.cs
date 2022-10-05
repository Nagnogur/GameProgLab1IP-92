using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 3.0f;
    [SerializeField] private float jumpPower;
    [SerializeField] private int maxJumps;
    private int jumpNumber;
    private bool isGrounded = false;

    private Rigidbody2D _rigidBody;
    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        jumpNumber = maxJumps;
    }
    private void Update()
    {
        _rigidBody.velocity = new Vector2(Input.GetAxis("Horizontal") * playerSpeed, _rigidBody.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || jumpNumber > 0))
        {
            Debug.Log("jumped");
            isGrounded = false;
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, jumpPower);
            jumpNumber--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            jumpNumber = maxJumps;
        }
    }
}