using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KnockBackSkeleton : MonoBehaviour
{
    public static KnockBackSkeleton instance;
    private Rigidbody2D rb;
    private Vector2 direction;
    private bool knockBackTrue = false;
    private float knockbackPower = 10;
    private Collider2D thisCollider;
    private Animator animator;
    private int health;
    public ParticleSystem boneExplosion;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        thisCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        health = 3;
    }

    private void Update()
    {
        if (knockBackTrue == true)
        {
            rb.AddForce(-direction * knockbackPower * 300 * Time.deltaTime);
        }
        else
        {
            rb.velocity = new Vector2(0,0);
        }
    }

    public IEnumerator Knockback(
        Transform obj)
    {
        direction = (obj.transform.position
                - this.transform.position).normalized;
        knockBackTrue = true;
        animator.SetBool("isHit", true);
        thisCollider.enabled = false;

        yield return new WaitForSeconds(.45f);

        knockBackTrue = false;
        animator.SetBool("isHit", false);

        if (health <= 0)
        {
            Instantiate(boneExplosion, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 7), new Quaternion(0, 0, 0, 0));
            boneExplosion.Play();
            Destroy(gameObject);
        }

        yield return new WaitForSeconds(1.5f);
        thisCollider.enabled = true;

        

        yield return 0;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Shuriken")
        {
            health--;
            StartCoroutine(Knockback(collision.transform));
        }
    }

}
