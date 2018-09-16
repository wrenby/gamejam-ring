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
        numRings = getMaxRingNum();
        for (int i = 0; i < numRings; i++)
        {
            GameObject newRing = Instantiate(rings[i]);
            float scale = 100*(ringBuffer) / rings[0].GetComponent<SpriteRenderer>().sprite.rect.width;
            newRing.transform.localScale = new Vector3(scale, scale, scale);
            newRing.transform.position = center;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public int getMaxRingNum()
    {
        return Mathf.Min(rings.Length, numRings);
    }
    public float getMinRadius()
    {
        return ringBuffer / 2;
    }
    public float getMaxRadius()
    {
        return ringBuffer * getMaxRingNum() / 2;
    }
}
