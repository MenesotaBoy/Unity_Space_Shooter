﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable] public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

    [SerializeField] Boundary boundary;
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject shot;
    [SerializeField] Transform shotSpawn;
    [SerializeField] float speed;
    [SerializeField] float tilt;
    [SerializeField] float fireRate;
    float nextFire;

    void Start()
    {
        rb = GetComponent <Rigidbody> ();
    }

    void Update()
    {
        //if (Input.GetButton("Fire1") && Time.time > nextFire)
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }

	void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}
 