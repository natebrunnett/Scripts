using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ShurikenScript : MonoBehaviour
{
    private Vector2 worldPosition;
    private Vector2 endPosition;
    public GameObject [] playerTransform;
    public float rightXBounds, leftXBounds;
    public float topYBounds, bottomYBounds;

    //lerp one
    private float percentageComplete;
    private Vector2 mousePosition;
    private Vector2 startPosition;
    private float desiredDuration = 1f;
    private float elapsedTime;
    [SerializeField]
    private AnimationCurve curve;

    //lerp two
    private float percentageComplete2;
    //using endposition
    private Vector2 startPosition2;
    private float desiredDuration2 = 1f;
    private float elapsedTime2;
    [SerializeField]
    private AnimationCurve curve2;

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Skeleton")
        {
            StartCoroutine(KnockBackSkeleton.instance.Knockback(this.transform));
        }
    }
    */



    void Start()
    {
        rightXBounds = 19.5f;
        leftXBounds = -19.5f;
        topYBounds = 10.5f;
        bottomYBounds = -10.5f;
        playerTransform = GameObject.FindGameObjectsWithTag("Player");

        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        startPosition = playerTransform[0].transform.position;
        mousePosition = worldPosition;
        endPosition = mousePosition;

        //I
        if (worldPosition.x < playerTransform[0].transform.position.x
            && worldPosition.y > playerTransform[0].transform.position.y
            )
        {
            while (endPosition.x > leftXBounds && endPosition.y < topYBounds)
            {
                endPosition.x -= 1;
                endPosition.y += 1;
            }
        }

        //II
        if (worldPosition.x > playerTransform[0].transform.position.x
            && worldPosition.y > playerTransform[0].transform.position.y
            )
        {
            while (endPosition.x < rightXBounds && endPosition.y < topYBounds)
            {
                endPosition.x += 1;
                endPosition.y += 1;
            }
        }

        //III
        if (worldPosition.x < playerTransform[0].transform.position.x
            && worldPosition.y < playerTransform[0].transform.position.y
            )
        {
            while (endPosition.x > leftXBounds && endPosition.y > bottomYBounds)
            {
                endPosition.x -= 1;
                endPosition.y -= 1;
            }
        }

        //IV
        if (worldPosition.x > playerTransform[0].transform.position.x
            && worldPosition.y < playerTransform[0].transform.position.y
            )
        {
            while (endPosition.x < rightXBounds && endPosition.y > bottomYBounds)
            {
                endPosition.x += 1;
                endPosition.y -= 1;
            }
        }
    }
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 15));

        if (percentageComplete < 1)
        {
            elapsedTime += Time.deltaTime;
            percentageComplete =
                elapsedTime / desiredDuration;

            transform.position = Vector2.Lerp(startPosition, mousePosition, curve.Evaluate(percentageComplete));
        }
        else if (percentageComplete2 < 1)
        {
            startPosition2 = mousePosition;

            elapsedTime2 += Time.deltaTime;
            percentageComplete2 =
                elapsedTime2 / desiredDuration2;

            transform.position = Vector2.Lerp(startPosition2, endPosition, curve2.Evaluate(percentageComplete2));
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

