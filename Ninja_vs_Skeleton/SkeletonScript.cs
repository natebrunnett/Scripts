using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonScript : MonoBehaviour
{
    private float speed = 2.0f;
    private GameObject [] playerTransform;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectsWithTag("Player");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = playerTransform[0].transform.position - this.transform.position;
        this.transform.Translate(direction.normalized * speed * Time.deltaTime);

        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
    }

    
}
