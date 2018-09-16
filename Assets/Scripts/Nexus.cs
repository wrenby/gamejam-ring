using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nexus : MonoBehaviour {


    public int maxHp;
    int hp;
    public Text hpText;
	void Start () {
        hp = maxHp;
	}
	
	// Update is called once per frame
	void Update () {
        hpText.text = "Nexus Health: " + hp;
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
