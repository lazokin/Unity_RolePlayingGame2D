using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{
	[SerializeField] private GameObject sprite;
	[SerializeField] private float speed = 4.0f;

    private Rigidbody2D rigidBody2D;
    private Animator anim;
    private float movePlayerVector;
    private bool facingRight;

    void Awake()
    {
		rigidBody2D = GetComponent<Rigidbody2D>();
		anim = sprite.GetComponent<Animator>();
    }

    void Update()
    {
        movePlayerVector = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(movePlayerVector));
		rigidBody2D.velocity = new Vector2(movePlayerVector * speed, rigidBody2D.velocity.y);
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
		Vector3 theScale = sprite.transform.localScale;
        theScale.x *= -1;
		sprite.transform.localScale = theScale;
    }
}
