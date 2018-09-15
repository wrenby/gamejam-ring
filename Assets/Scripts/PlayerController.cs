using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Vector2 center;
    public float radiusIncrement, angleSpeed, minRadius = 2, maxRadius = 12;
    float radius, angle;
    GameObject player;
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
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
        if (Input.GetKey(KeyCode.D))
        {
            angle += angleSpeed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            angle -= angleSpeed;
        }
        if (minRadius > radius)
            radius = minRadius;
        if (radius > maxRadius)
            radius = maxRadius;
        player.transform.position = new Vector2(radius * Mathf.Cos(angle) + center.x, radius * Mathf.Sin(angle) + center.y);

	}
}
