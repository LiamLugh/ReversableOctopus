using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Rigidbody rb;
    public float shipSpeed = 1.0f;
    public float maxSpeed = 5.0f;
    public float minSpeed = 0.0f;
    public float increment = 0.5f;

    void Update()
    {
        //ship movement for keypress
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(rb.velocity.z < maxSpeed)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z + increment);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (rb.velocity.z > minSpeed)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z - increment);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (rb.velocity.x > (-maxSpeed))
            {
                rb.velocity = new Vector3(rb.velocity.x + increment, rb.velocity.y, rb.velocity.z);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (rb.velocity.x < maxSpeed)
            {
                rb.velocity = new Vector3(rb.velocity.x - increment, rb.velocity.y, rb.velocity.z);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //checks collided trigger for death or score increment
        if (other.gameObject.name == "Animal")
        {
            //increment count
            //add icon to inventory
            Destroy(other.gameObject);
        }
    }

}
