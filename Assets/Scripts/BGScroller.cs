using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {

    [SerializeField] float scrollSpeed;
    [SerializeField] float tileSizeZ;
    [SerializeField] float newPos;

    private Vector3 startPosition;

	void Start () {
        startPosition = transform.position;
	}
	
	void Update () {
        newPos = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPos;
	}
}
