using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public bool friendly = true;
    public int damage = 10;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int getDamage()
    {
        return damage;
    }
}
