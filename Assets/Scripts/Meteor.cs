using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {

    // Use this for initialization
    private Vector2 center;
    private RingManager ringMan;
    public float speed = 10f;
    private float hp;
    public int minResources = 50, maxResources = 100, damage = 100, maxHp = 100;
    void Start () {
        ringMan = GameObject.FindGameObjectWithTag("RingManager").GetComponent<RingManager>();
        center = ringMan.center;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale == 0)
            return;
        this.GetComponent<Rigidbody2D>().velocity = (((Vector2)transform.position) - center).normalized * -speed * 1 / (transform.localScale.x);
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
        this.hp = this.maxHp;
    }
    public void takeDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().getResources((int)Random.Range(minResources, maxResources + 1));
            AudioSource audio = GameObject.FindGameObjectWithTag("Exploder").GetComponent<AudioSource>();
            audio.enabled = true;
            audio.Play();
            Destroy(this.gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject otherObj = collider.gameObject;
        if(otherObj.tag == "Bullet")
        {
            if (otherObj.GetComponent<Bullet>().friendly)
            {
                takeDamage(otherObj.GetComponent<Bullet>().getDamage());
                Destroy(otherObj);
            }
        }
        else if(otherObj.tag == "Nexus")
        {
            otherObj.GetComponent<Nexus>().takeDamage(damage);
            takeDamage(maxHp);
        }
        else if(otherObj.tag == "Tower")
        {
            otherObj.GetComponent<Orbiter>().takeDamage(damage);
            int turretHp = otherObj.GetComponent<Orbiter>().getHp();
            if(turretHp > 0)
            {
                takeDamage(maxHp);
            }
            else
            {
                takeDamage(damage + turretHp);
            }
        }
    }
}
