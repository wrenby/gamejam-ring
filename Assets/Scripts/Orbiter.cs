using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SimpleMesh), typeof(MeshRenderer))]
public class Orbiter : MonoBehaviour {
	public const float RAD_TO_DEG = 180.0f/Mathf.PI;
	public const float TWO_PI = 2*Mathf.PI;
    public int cost;
    public float fireDelay = 0.2f;
    private float lastFireTime = 0.0f;
    private RingManager ringMan;
    public bool canFire = true;
    public float rotationSpeed = 50.0f;
    [Range(0.0f, 100.0f)]
    public float rho = 500.0f;
	[Range(0.0f, TWO_PI)]
	public float theta = 0.0f; // Angle

    public int maxHp = 100;
    private int hp;

    public GameObject ring;

	// Projectile info
	[Range(0.0f, 40.0f)]
	public float projectile_speed = 16.0f;
	// Projectile prefabs
	public GameObject projectile_basic;

    public void Start()
    {
        ringMan = GameObject.FindGameObjectWithTag("RingManager").GetComponent<RingManager>();
        hp = maxHp;
    }
    private Vector3 CartesianPosition() {
		return new Vector3( // theta = 0 is up
			rho*Mathf.Sin(theta),
			rho*Mathf.Cos(theta),
			-1
		);
	}

	void Update() {
        if (Time.timeScale == 0)
            return;
        if (ringMan.getSelectedRing().transform == transform.parent)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                theta += rotationSpeed;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                theta -= rotationSpeed;
            }
        }
        if (canFire && Input.GetButton("Fire1") && lastFireTime + fireDelay <= Time.time)
        {
            Projectile clone = GameObject.Instantiate(projectile_basic, transform.position, transform.rotation).GetComponent<Projectile>();
            clone.speed = projectile_speed;
            clone.forward = new Vector3( // Already normalized thanks to sin & cos
                Mathf.Sin(theta),
                Mathf.Cos(theta),
                0
            );
            lastFireTime = Time.time;
        }
        theta = theta % TWO_PI;
		transform.position = CartesianPosition();
		transform.rotation = Quaternion.Euler(0,0,-theta*RAD_TO_DEG);
	}

    public void setTheta(float newTheta)
    {
        this.theta = newTheta;
    }
    
    public void setRho(float newRho)
    {
        this.rho = newRho;
    }

    public void takeDamage(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            AudioSource audio = gameObject.GetComponent<AudioSource>();
            audio.enabled = true;
            audio.Play();
            Destroy(this.gameObject);
        }
    }
    public int getHp()
    {
        return hp;
    }
}