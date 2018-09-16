using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCreator : MonoBehaviour {

    public GameObject meteor;
    private float startTime, lastCreation, delay;
    private RingManager ringMan;
    public int rate = 100, damageRate = 50;
    public float lowScale = 0.3f, highScale = 1.0f;
	// Use this for initialization
	void Start () {
        delay = 5.0f;
        startTime = Time.time;
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
            float newScale = Random.Range(lowScale, highScale);
            newMeteor.transform.localScale = new Vector3(newScale, newScale, newScale);
            newMeteor.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, Mathf.PI * 2));
            Meteor newMeteorScript = newMeteor.GetComponent<Meteor>();
            newMeteorScript.setMaxHP((int)((1 + newScale)*rate * ((deltaTime/60 + 5))));
            newMeteorScript.setDamage((int)((1+newScale)*damageRate * ((deltaTime / 60 + 1))));
            delay *= .99f;
            lastCreation = Time.time;
        }
	}
}
