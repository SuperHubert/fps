using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 1;
    public float jumpForce = 100;
    
    public float verticalAxis;
    public float horizontalAxis;

    private Vector3 direction;

    public bool isGrounded;
    

    void Update()
    {
        direction = (transform.forward * verticalAxis + transform.right * horizontalAxis).normalized;
        
        rb.velocity = direction  * speed * Time.deltaTime + new Vector3(0,rb.velocity.y,0);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(transform.up*jumpForce);
        }
        
    }
    
}
