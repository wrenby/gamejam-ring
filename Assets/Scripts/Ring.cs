using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour {
    public Sprite unselected, selected;
    private RingManager ringMan;
    private int layer;
	void Start () {
        ringMan = GameObject.FindGameObjectWithTag("RingManager").GetComponent<RingManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(ringMan.getSelectedRing() == this.gameObject)
        {
            GetComponent<SpriteRenderer>().sprite = selected;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = unselected;
        }
	}

    public void setLayer(int layer)
    {
        this.layer = layer;
    }
}
