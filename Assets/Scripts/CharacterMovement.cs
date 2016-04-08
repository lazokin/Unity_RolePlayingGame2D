using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D playerRigidBody2D;
    private GameObject playerSprite;
    private Animator anim;
    private float movePlayerVector;
    private bool facingRight;

    public float speed = 4.0f;

    void Awake()
    {
        playerRigidBody2D = GetComponent<Rigidbody2D>();
        playerSprite = transform.Find("PlayerSprite").gameObject;
        anim = playerSprite.GetComponent<Animator>();
    }

    void Update()
    {
        movePlayerVector = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(movePlayerVector));
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
        Vector3 theScale = playerSprite.transform.localScale;
        theScale.x *= -1;
        playerSprite.transform.localScale = theScale;
    }
}
