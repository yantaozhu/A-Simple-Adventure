using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    SpriteRenderer sprite;
    Animator animator;

    float horizontal;
    float speed = 5.0f;

    private enum MovementState { idle, run, jump, fall }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
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
        rigidbody2d.velocity = new Vector2(horizontal * speed, 0f);
        
        if(Input.GetKey("space"))
        {
            rigidbody2d.velocity = new Vector2(horizontal * speed, 10.0f);
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

        if (rigidbody2d.velocity.y > 0f)
        {
            state = MovementState.jump;
        }
        else if (rigidbody2d.velocity.y < 0f)
        {
            state = MovementState.fall;
        }

        animator.SetInteger("State", (int)state);
    }
}
