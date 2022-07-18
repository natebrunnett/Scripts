using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenGenerator : MonoBehaviour
{
    public GameObject shuriken, shurikenKeyboard;
    public Transform playerTransform;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && GameScript.instance.mousePlay == true)
        {
            Instantiate(shuriken, playerTransform.position, new Quaternion (0,0,0,0));
        }

        if (Input.GetKeyDown(KeyCode.Space) && GameScript.instance.keyboardPlay == true)
        {
            Instantiate(shurikenKeyboard, playerTransform.position, new Quaternion(0, 0, 0, 0));
        }
    }
}
