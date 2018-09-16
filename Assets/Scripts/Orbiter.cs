using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SimpleMesh), typeof(MeshRenderer))]
public class Orbiter : MonoBehaviour {
	[Range(0.0f, 100.0f)]
	public float rho = 20.0f; // Distance
	[Range(0.0f, 2*Mathf.PI)]
	public float theta = 0.0f; // Angle

	MeshRenderer mesh_renderer;
	SimpleMesh mesh;

	private Vector3 CartesianPosition() {
		return new Vector3( // theta = 0 is above
			rho*Mathf.Sin(theta),
			rho*Mathf.Cos(theta),
			transform.localPosition.z
		);
	}

	void Start() {
		mesh_renderer = GetComponent<MeshRenderer>();
		mesh = GetComponent<SimpleMesh>();
	}

	const float RAD_TO_DEG = 180.0f/Mathf.PI;

	void Update() {
		transform.localPosition = CartesianPosition();
		transform.localRotation = Quaternion.Euler(0,0,-theta*RAD_TO_DEG);
	}
}