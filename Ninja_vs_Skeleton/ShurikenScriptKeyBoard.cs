using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenScriptKeyBoard : MonoBehaviour
{
    private Vector2 moveInput;
    private float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

    }
   
    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 0, 20);
        Vector2 direction = moveInput;
        if (direction.normalized != new Vector2(0, 0))
        {
            this.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }
        else
        {
            Destroy(gameObject);
        }

        if (this.transform.position.x < -19.5f || this.transform.position.x > 19.5f ||
            this.transform.position.y > 10.5f || this.transform.position.y < -10.5f)
        {
            Destroy(gameObject);
        }

    }


}
