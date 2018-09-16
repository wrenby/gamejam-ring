using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingManager : MonoBehaviour {
    public GameObject[] rings;
    public int numRings;
    public float ringBuffer = 1.0f;
    public Vector2 center;
    // Use this for initialization
    void Start () {
        numRings = Mathf.Min(rings.Length, numRings);
        for (int i = 0; i < numRings; i++)
        {
            GameObject newRing = Instantiate(rings[i]);
            print(newRing.GetComponent<SpriteRenderer>().sprite.rect.width);
            float scale = 100*ringBuffer / rings[0].GetComponent<SpriteRenderer>().sprite.rect.width;
            newRing.transform.localScale = new Vector3(scale, scale, scale);
            newRing.transform.position = center;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
