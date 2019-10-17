using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

    [SerializeField] float tumble;
    [SerializeField] Rigidbody rb;

    void Start()
    {
        rb.angularVelocity = Random.insideUnitSphere * tumble;
    }


}
