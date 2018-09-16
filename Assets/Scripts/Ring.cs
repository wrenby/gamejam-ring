using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour {
    public Sprite unselected, selected;
    private RingManager ringMan;
	void Start () {
        ringMan = GameObject.FindGameObjectWithTag("RingManager").GetComponent<RingManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale == 0)
            return;
		if(ringMan.getSelectedRing() == this.gameObject)
        {
            GetComponent<SpriteRenderer>().sprite = selected;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = unselected;
        }
	}
}
