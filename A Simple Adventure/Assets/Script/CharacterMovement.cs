using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    BoxCollider2D collider;
    SpriteRenderer sprite;
    Animator animator;

    float horizontal;
    float speed = 5f;
    float jumpForce = 8f;

    [SerializeField] private LayerMask jumpableGround;

    private enum MovementState { idle, run, jump, fall }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        rigidbody2d.velocity = new Vector2(horizontal * speed, rigidbody2d.velocity.y);
        
        if(Input.GetKey("space") && IsGrounded())
        {
            rigidbody2d.velocity = new Vector2(horizontal * speed, jumpForce);
        }

        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        MovementState state;

        if (horizontal > 0f)
        {
            state = MovementState.run;
            sprite.flipX = false;
        }
        else if (horizontal < 0f)
        {
            state = MovementState.run;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rigidbody2d.velocity.y > 0.1f)
        {
            state = MovementState.jump;
        }
        else if (rigidbody2d.velocity.y < -0.1f)
        {
            state = MovementState.fall;
        }

        animator.SetInteger("State", (int)state);
    }

    bool IsGrounded()
    {
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            Death();
        }
    }

    void Death()
    {
        animator.SetTrigger("Death");
        rigidbody2d.bodyType = RigidbodyType2D.Static;
    }

    void RestartLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
