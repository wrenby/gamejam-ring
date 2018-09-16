using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Nexus : MonoBehaviour {


    public int maxHp;
    int hp;
    public Text hpText, gameOverText;
	void Start () {
        hp = maxHp;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (gameOverText.enabled && Input.GetKeyDown(KeyCode.Space)) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1;
        }
        hpText.text = "Nexus Health: " + hp;
        gameOverText.enabled = hp <= 0;
	}

    public void takeDamage(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            hp = 0;
            Time.timeScale = 0;
            gameOverText.enabled = true;
        }
    }
}
