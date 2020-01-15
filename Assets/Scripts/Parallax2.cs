using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax2 : MonoBehaviour
{
	private float length, startposX;
	public GameObject cam;
	public float parallaxEffectX;
    // Start is called before the first frame update
    void Start()
    {
        startposX = transform.position.x;
	length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distX = (cam.transform.position.x * parallaxEffectX);

	transform.position = new Vector3(startposX + distX, transform.position.z, transform.position.z);
    }
}
