using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D playerRigidBody2D;
    private float movePlayerVector;
    private bool facingRight;

    public float speed = 4.0f;

    void Awake()
    {
        playerRigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movePlayerVector = Input.GetAxis("Horizontal");
        playerRigidBody2D.velocity = new Vector2(movePlayerVector * speed, playerRigidBody2D.velocity.y);
        if (movePlayerVector > 0 && !facingRight)
        {
            Flip();
        }
        else if (movePlayerVector < 0 && facingRight)
        {
            Flip();
        }
    }
	
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
