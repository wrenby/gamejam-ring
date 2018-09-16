using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Vector2 center;
    public float speed = .2f;
    public GameObject turret;
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
        angle = angle % Orbiter.TWO_PI;
        player.transform.position = new Vector2(radius * Mathf.Sin(angle) + center.x, radius * Mathf.Cos(angle) + center.y);
        player.transform.up = (Vector2)player.transform.position - center;
        if (Input.GetKeyDown(KeyCode.E))
        {
            placeTurret();
        }
    }

    public void getResources(int amount)
    {
        resources += amount;
    }

    private void placeTurret()
    {
        Orbiter turretScript = turret.GetComponent<Orbiter>();
        if(resources >= turretScript.cost)
        {
            resources -= turretScript.cost;
            GameObject ring = ringMan.getRing(transform.position);
            GameObject newTurret = Instantiate(turret,ring.transform);
            Orbiter newTurretScript = newTurret.GetComponent<Orbiter>();
            newTurretScript.setTheta(angle);
            newTurretScript.setRho(radius);
        }
    }
}
