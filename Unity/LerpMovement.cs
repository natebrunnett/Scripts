using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMovement : MonoBehaviour
{
    private Vector3 endPosition = new Vector3(5, 1, 0);
    private Vector3 startPosition;
    private float desiredDuration = 3f;
    private float elapsedTime;
    [SerializeField]
    private AnimationCurve curve;

    void Start()
    {
        //intialize the start position at runtime
        startPosition = transform.position;    
    }

    void Update()
    {
        //call while lerp is active
        elapsedTime += Time.deltaTime;
        float percentageComplete =
            elapsedTime / desiredDuration;
        transform.position = Vector3.Lerp(startPosition, endPosition, curve.Evaluate(percentageComplete));
        Debug.Log(percentageComplete);
    }
}

//curve.Evaluate needs to be set in the inspector
