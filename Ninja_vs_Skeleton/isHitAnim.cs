using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isHitAnim : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Collider2D thisCollider;

    void Start()
    {
        //Fetch the SpriteRenderer from the GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();
        thisCollider = GetComponent<Collider2D>();
    }
    
    public IEnumerator isHit()
    {
        while (thisCollider.enabled == false)
        {
            spriteRenderer.color = new Color(.6f, .7f, 1);
            yield return new WaitForSeconds(.075f);
            spriteRenderer.color = new Color(.8f, .9f, 1);
            yield return new WaitForSeconds(.075f);
        }

        spriteRenderer.color = new Color(1, 1, 1);
        yield return 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Skeleton")
        {
            StartCoroutine(isHit());
        }
    }
}
