using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nexus : MonoBehaviour {


    public int maxHp;
    int hp;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void takeDamage(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            //Lose the game lol
        }
    }
}
