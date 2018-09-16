using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingManager : MonoBehaviour {
    public GameObject[] rings;
    private GameObject[] myRings;
    private int selectedRing;
    public int numRings;
    public float ringBuffer = 1.0f;
    public Vector2 center;
    // Use this for initialization
    void Start () {
        selectedRing = 0;
        myRings = new GameObject[getMaxRingNum()];
        numRings = getMaxRingNum();
        for (int i = 0; i < numRings; i++)
        {
            GameObject newRing = Instantiate(rings[i]);
            float scale = 100*(ringBuffer) / rings[0].GetComponent<SpriteRenderer>().sprite.rect.width;
            newRing.transform.localScale = new Vector3(scale, scale, scale);
            newRing.transform.position = center;
            myRings[i] = newRing;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedRing++;
            selectedRing = Mathf.Min(selectedRing, numRings - 1);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedRing--;
            selectedRing = Mathf.Max(selectedRing, 0);
        }
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
    public GameObject getRing(Vector2 position)
    {
        int index = Mathf.RoundToInt(2 * Vector2.Distance(position, center) / ringBuffer) - 1;
        return myRings[index];
    }
    public GameObject getSelectedRing()
    {
        return myRings[selectedRing];
    }
}
