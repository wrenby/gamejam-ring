using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCreator : MonoBehaviour {

    public GameObject meteor;
    private float startTime, lastCreation, lastFrequency, delay;
    private RingManager ringMan;
    public int hpRate = 750, damageRate = 50;
    public float lowScale = 0.3f, highScale = 1.0f;
	// Use this for initialization
	void Start () {
        delay = 5.0f;
        startTime = Time.time;
        lastCreation = startTime;
        lastFrequency = startTime;
        ringMan = GameObject.FindGameObjectWithTag("RingManager").GetComponent<RingManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale == 0)
            return;
        float deltaTime = Time.time - startTime;
        if(lastCreation + delay < Time.time)
        {
            GameObject newMeteor = Instantiate(meteor);
            float angle = Random.Range(0, 2 * Mathf.PI);
            float radius = ringMan.getMaxRadius() * 3f;
            newMeteor.transform.position = new Vector2(radius * Mathf.Sin(angle), radius * Mathf.Cos(angle));
            float newScale = Random.Range(lowScale, highScale);
            newMeteor.transform.localScale = new Vector3(newScale, newScale, newScale);
            newMeteor.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, Mathf.PI * 2));
            Meteor newMeteorScript = newMeteor.GetComponent<Meteor>();
            newMeteorScript.setMaxHP((int)((newScale + deltaTime/60)*hpRate));
            newMeteorScript.setDamage((int)((1 + newScale)*damageRate * ((deltaTime / 60 + 1))));
            lastCreation = Time.time;
        }
        if (lastFrequency + 5 < Time.time) { // Decreasing the delay is its own tick
            delay *= .95f;
            lastFrequency = Time.time;
        }
	}
}
