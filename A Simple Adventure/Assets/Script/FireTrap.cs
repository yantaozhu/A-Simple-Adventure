using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    [SerializeField] float fireRate;
    private float nextFire;

    Animator animator;
    BoxCollider2D boxcollider;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        boxcollider = GetComponent<BoxCollider2D>();
        GetComponent<BoxCollider2D>().size = new Vector2(0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            animator.SetBool("FireOn", true);
            GetComponent<BoxCollider2D>().size = new Vector2(0.75f, 2f);
        }
    }

    void Idle() {
        animator.SetBool("FireOn", false);
        GetComponent<BoxCollider2D>().size = new Vector2(0f, 0f);
    }
}
