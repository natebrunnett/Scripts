using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isHitAnimSkeleton : MonoBehaviour
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
            spriteRenderer.color = new Color(1f, .5f, .3f);
            yield return new WaitForSeconds(.075f);
            spriteRenderer.color = new Color(1f, .7f, .6f);
            yield return new WaitForSeconds(.075f);
        }

        spriteRenderer.color = new Color(1, 1, 1);
        yield return 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Shuriken")
        {
            StartCoroutine(isHit());
        }
    }
}
