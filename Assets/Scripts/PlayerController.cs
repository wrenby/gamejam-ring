﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Vector2 center;
    public float speed = .2f;
    float radius, angle, radiusIncrement, minRadius, maxRadius;
    int resources;
    GameObject player;
    RingManager ringMan;
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        ringMan = GameObject.FindGameObjectWithTag("RingManager").GetComponent<RingManager>();
        radiusIncrement = ringMan.ringBuffer/2;
        minRadius = ringMan.getMinRadius();
        maxRadius = ringMan.getMaxRadius();
        center = ringMan.center;
        resources = 0;
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
        player.transform.up = (Vector2)player.transform.position - center;
	}

    public void getResources(int amount)
    {
        resources += amount;
    }
}
