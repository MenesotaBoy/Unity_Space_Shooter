using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    [SerializeField] Rigidbody rd;
    [SerializeField] float speed;

    void Start()
    {
        rd.velocity = transform.forward * speed;
    }
}
