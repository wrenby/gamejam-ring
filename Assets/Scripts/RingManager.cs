using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingManager : MonoBehaviour {
    private float scale;
    public GameObject ring;
    public int numRings = 5;
    public float ringBuffer = 2.0f;
    public Vector2 center;
    // Use this for initialization
    void Start () {
        scale = ringBuffer / 1.89332084f;
        for(int i = 1; i <= numRings; i++)
        {
            GameObject newRing = Instantiate(ring);
            newRing.transform.localScale = new Vector3(scale*i, scale*i, scale*i);
            newRing.transform.position = center;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
