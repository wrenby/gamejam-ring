using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Vector2 center;
    public float speed = .2f;
    float radius, angle, radiusIncrement, minRadius, maxRadius;
    GameObject player;
    RingManager ringMan;
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        ringMan = GameObject.FindGameObjectWithTag("RingManager").GetComponent<RingManager>();
        radiusIncrement = ringMan.ringBuffer/2;
        minRadius = radiusIncrement;
        maxRadius = radiusIncrement * ringMan.numRings;
        center = ringMan.center;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.W))
        {
            radius += radiusIncrement;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            radius -= radiusIncrement;
        }
        if (minRadius > radius)
            radius = minRadius;
        if (radius > maxRadius)
            radius = maxRadius;
        if (Input.GetKey(KeyCode.D))
        {
            angle += speed/radius;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            angle -= speed/radius;
        }
        player.transform.position = new Vector2(radius * Mathf.Cos(angle) + center.x, radius * Mathf.Sin(angle) + center.y);

	}
}
