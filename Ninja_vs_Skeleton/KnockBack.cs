using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KnockBack : MonoBehaviour
{
    public static KnockBack instance;
    private Rigidbody2D rb;
    private Vector2 direction;
    private bool knockBackTrue = false;
    private float knockbackPower = 100;
    private Collider2D thisCollider;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        thisCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (knockBackTrue == true)
        {
            rb.AddForce(-direction * knockbackPower * 1000 * Time.deltaTime);  
        }
    }

    public IEnumerator Knockback(Transform obj)
    {
        direction = (obj.transform.position
                - this.transform.position).normalized;
 
        knockBackTrue = true;
        thisCollider.enabled = false;
            
        yield return new WaitForSeconds(.075f);
        
        knockBackTrue = false;

        yield return new WaitForSeconds(2);
        thisCollider.enabled = true;

        yield return 0;
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Skeleton")
        {
            StartCoroutine(Knockback(collision.transform));
            //StartCoroutine(KnockBack.instance.isHit());
        }
    }

}
