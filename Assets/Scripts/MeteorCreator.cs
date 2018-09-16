using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCreator : MonoBehaviour {

    public GameObject meteor;
    private float startTime, lastCreation, delay;
    private RingManager ringMan;
    public int rate = 100, damageRate = 50;
	// Use this for initialization
	void Start () {
        delay = 5.0f;
        lastCreation = startTime;
        ringMan = GameObject.FindGameObjectWithTag("RingManager").GetComponent<RingManager>();
	}
	
	// Update is called once per frame
	void Update () {
        float deltaTime = Time.time - startTime;
        if(lastCreation + delay < Time.time)
        {
            GameObject newMeteor = Instantiate(meteor);
            float angle = Random.Range(0, 2 * Mathf.PI);
            float radius = ringMan.getMaxRadius() * 1.5f;
            newMeteor.transform.position = new Vector2(radius * Mathf.Sin(angle), radius * Mathf.Cos(angle));
            Meteor newMeteorScript = newMeteor.GetComponent<Meteor>();
            newMeteorScript.setMaxHP((int)(rate * ((deltaTime/60 + 5))));
            newMeteorScript.setDamage((int)(damageRate * ((deltaTime / 60 + 5))));
            delay *= .99f;
            lastCreation = Time.time;
        }
	}
}
