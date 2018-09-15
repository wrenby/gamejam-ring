using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SimpleMesh))]
public class Orbiter : MonoBehaviour {
	[Range(0.0f, 100.0f)]
	public float phi = 20.0f;
	public float theta = 0.0f;
}