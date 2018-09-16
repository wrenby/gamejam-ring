using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SimpleMesh), typeof(MeshRenderer))]
public class Orbiter : MonoBehaviour {
	const float RAD_TO_DEG = 180.0f/Mathf.PI;
	const float TWO_PI = 2*Mathf.PI;

	[Range(0.0f, 100.0f)]
	public float rho = 1.0f; // Distance
	[Range(0.0f, TWO_PI)]
	public float theta = 0.0f; // Angle

	// Projectile info
	public float projectile_offset = 0.04f; // Distance from center of the ship to spawn the bullets
	[Range(0.0f, 40.0f)]
	public float projectile_speed = 1000.0f;
	// Projectile prefabs
	public GameObject projectile_basic;

	private Vector3 CartesianPosition() {
		return new Vector3( // theta = 0 is above
			rho*Mathf.Sin(theta),
			rho*Mathf.Cos(theta),
			transform.localPosition.z
		);
	}

	void Update() {
		theta = (theta + Input.GetAxis("Horizontal")) % TWO_PI; // Maybe temporary idk

		transform.localPosition = CartesianPosition();
		transform.localRotation = Quaternion.Euler(0,0,-theta*RAD_TO_DEG);

		if (Input.GetButtonDown("Fire1")) {
			Projectile clone = GameObject.Instantiate(projectile_basic, transform.position, transform.rotation).GetComponent<Projectile>();
			clone.speed = projectile_speed;
			clone.forward = new Vector3( // Already normalized thanks to sin & cos
				Mathf.Sin(theta),
				Mathf.Cos(theta),
				0
			);
		}
	}
}