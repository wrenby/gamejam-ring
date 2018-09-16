using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D), typeof(MeshRenderer), typeof(MeshFilter))]
public class SimpleMesh : MonoBehaviour {
	public Vector2[] mesh_points;
	[SerializeField]
	private MeshFilter mesh_filter;
	[SerializeField]
	private PolygonCollider2D poly_collider;
	private Mesh mesh;

	void Start () {
		SetMesh();
	}

	public void SetMesh() {
		Triangulator triangulator = new Triangulator(mesh_points);
        int[] triangles = triangulator.Triangulate();
        mesh = new Mesh();

        List<Vector3> meshPoint3s = new List<Vector3>();
        foreach (Vector2 v in mesh_points)
        {
            meshPoint3s.Add(v);
        }
        mesh.vertices = meshPoint3s.ToArray();
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
		mesh.name = "SimpleMesh";

        mesh_filter.mesh = mesh;
        poly_collider.points = mesh_points;
	}
}
