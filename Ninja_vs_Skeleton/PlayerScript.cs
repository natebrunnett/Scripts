using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript instance;
    public float moveSpeed = 5;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;
    public Animator heartsAnimator;
    private int health;
    public GameObject gameOverScreen;

    private void Awake()
    {
        instance = this;
    }

    public void setHealth(int hp)
    {
        health = hp;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = 3;
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();
        if (GameScript.instance.playState == true)
        {
            rb.velocity = moveInput * moveSpeed;
        }
        else
        { rb.velocity = new Vector2 (0,0 );
          transform.position = new Vector2(999, 999);
        }
       

        animator.SetFloat("Horizontal", moveInput.x);
        animator.SetFloat("Vertical", moveInput.y);
        animator.SetFloat("Speed", moveInput.sqrMagnitude);

        if (health == 0 || health < 0)
        {
            Debug.Log("Game OVer!");
            gameOverScreen.SetActive(true);
            GameScript.instance.playState = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Skeleton")
        {
            health--;
            heartsAnimator.SetInteger("Health", health);
        }
    }
}
