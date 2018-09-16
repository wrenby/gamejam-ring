using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    private Vector2 center;
    public float speed = .2f, tolerance = 1f;
    public GameObject turret, wall;
    public Text resourceText, timeText;
    public int startingResources = 100;
    float radius, angle, radiusIncrement, minRadius, maxRadius, startTime;
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
        startTime = Time.time;
        resources = startingResources;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale == 0)
            return;
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
        if (Input.GetKeyDown(KeyCode.R))
        {
            placeWall();
        }
        float deltaTime = Time.time - startTime;
        int seconds = ((int)deltaTime % 60);
        int minutes = ((int)deltaTime / 60);
        timeText.text = "Time Survived: " + minutes.ToString("00") + ":" + seconds.ToString("00");
        resourceText.text = "Scrap Metal: " + resources;
    }

    public void getResources(int amount)
    {
        resources += amount;
    }

    private void placeWall()
    {
        Orbiter wallScript = wall.GetComponent<Orbiter>();
        if(isClear() && resources >= wallScript.cost)
        {
            resources -= wallScript.cost;
            GameObject ring = ringMan.getRing(transform.position);
            GameObject newWall = Instantiate(wall, ring.transform);
            Orbiter newWallScript = newWall.GetComponent<Orbiter>();
            newWallScript.setTheta(angle);
            newWallScript.setRho(radius);
        }
    }

    private void placeTurret()
    {
        Orbiter turretScript = turret.GetComponent<Orbiter>();
        if(isClear() && resources >= turretScript.cost)
        {
            resources -= turretScript.cost;
            GameObject ring = ringMan.getRing(transform.position);
            GameObject newTurret = Instantiate(turret,ring.transform);
            Orbiter newTurretScript = newTurret.GetComponent<Orbiter>();
            newTurretScript.setTheta(angle);
            newTurretScript.setRho(radius);
            newTurretScript.ring = ring;
        }
    }

    private bool isClear()
    {
        GameObject ring = ringMan.getRing(transform.position);
        Orbiter[] orbiters = ring.GetComponentsInChildren<Orbiter>();
        for (int i = 0; i < orbiters.Length; i++) {
            if (Mathf.Abs(orbiters[i].theta%Orbiter.TWO_PI - angle%Orbiter.TWO_PI)%Mathf.PI * radius < tolerance)
            {
                return false;
            }
        }
        return true;
    }
}
