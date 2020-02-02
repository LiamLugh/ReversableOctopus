﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public GameManager gm;
    public Rigidbody rb;
    public float shipSpeed = 1.0f;
    public float maxSpeed = 5.0f;
    public float minSpeed = 0.0f;
    public float increment = 0.5f;
    Vector3 prePauseVelocity;

    void Update()
    {
        //ship movement for keypress
        if (Input.GetKeyDown(KeyCode.W))
        {
            if(rb.velocity.z < maxSpeed)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z + increment);
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (rb.velocity.z > (-maxSpeed))
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z - increment);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (rb.velocity.x > (-maxSpeed))
            {
                rb.velocity = new Vector3(rb.velocity.x + increment, rb.velocity.y, rb.velocity.z);
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (rb.velocity.x < maxSpeed)
            {
                rb.velocity = new Vector3(rb.velocity.x - increment, rb.velocity.y, rb.velocity.z);
            }
        }
        
    }
    public void pauseVelocity()
    {
        prePauseVelocity = rb.velocity;
        rb.velocity = Vector3.zero;
    }

    public void resumeVelocity()
    {
        rb.velocity = prePauseVelocity;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Animal")
        {
            AudioSource sound = other.gameObject.GetComponent<AudioSource>();
            sound.Play();

            if (gm.collectedAnimals.Count < Globals.levelPairCount+1)
            {
                gm.collectAnimal(other.gameObject.name);
                Destroy(other.gameObject);
            }
        }
        if(other.gameObject.tag == "Land")
        {
            rb.velocity *= (-0.5f);
        }
    }

    public void Fire(GameObject g)
    {
        GameObject creature = Instantiate(g, transform);
    }
}
