﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
	private float length, startposX, startposY;
	public GameObject cam;
	public float parallaxEffectX;
	public float parallaxEffectY;
    // Start is called before the first frame update
    void Start()
    {
        startposX = transform.position.x;
	length = GetComponent<SpriteRenderer>().bounds.size.x;
	startposY = transform.position.y;
	length = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distX = (cam.transform.position.x * parallaxEffectX);
	float distY = (cam.transform.position.y * parallaxEffectY);

	transform.position = new Vector3(startposX + distX, startposY + distY, transform.position.z);
    }
}
