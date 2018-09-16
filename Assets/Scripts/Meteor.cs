using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {

    // Use this for initialization
    private Vector2 center;
    private RingManager ringMan;
    public float speed = 10f;
    private float hp;
    public float minResources = 5, maxResources = 100, damage = 10, maxHp = 100;
    void Start () {
        ringMan = GameObject.FindGameObjectWithTag("RingManager").GetComponent<RingManager>();
        center = ringMan.center;
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Rigidbody2D>().velocity = (((Vector2)transform.position) - center).normalized * -speed;
	}
    public void setSpeed(float speed)
    {
        this.speed = speed;
    }
    public void setDamage(int damage)
    {
        this.damage = damage;
    }
    public void setMaxHP(int maxHp)
    {
        this.maxHp = maxHp;
    }
    public void takeDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            //die, whatever that means
        }
    }
}
