﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GageManager : MonoBehaviour {
    public Sprite winner;
    public Image winner_image;
    public Image player_gage;
    public CountStarter countStarter;
    public Animator anim;
	public GameObject head;
	public GameObject bang;
	public explosion _ex;


    public float player_health = 100f;


    float full_damage = 0f,damage=0;
    float cal = 100f;
    public float speed = 100f;
   
    public bool test = false;
	bool isDie = false;
	// Use this for initialization
	void Start () {
        player_gage.GetComponent<Image>().fillAmount = player_health / 100f;
    }

    // Update is called once per frame
    void Update () {
        if (test) {
            DamagePlayer(30);
            test = false;
        }
        if (player_health < cal) {
            player_gage.GetComponent<Image>().fillAmount = (cal) / 100f;
            player_health = cal;
            full_damage = 0;
            damage = 0;
        }
        else if (full_damage != damage && damage != 0)
        {
            full_damage += Time.deltaTime * speed;
            player_health -= Time.deltaTime * speed;
            player_gage.GetComponent<Image>().fillAmount = (player_health) / 100f;
        }
        else if (full_damage >= damage && damage != 0)
        {
            full_damage = 0;
            damage = 0;
           
           
        }

		if (player_health <= 0&& !isDie)
		{
			isDie = true;
			anim.SetBool("gg", true);
			ManagerScript.instance.gameEnd = true;
			SoundManager.instance.PlaySound(8);
			bang.transform.position = head.transform.position;
			_ex.ExFire(2);
			Invoke("Print", 7);
			
		}
	}
    public void DamagePlayer(int damage) { 
        this.damage += damage;
        cal -= damage;
    }

    public float GetPlayerHealth() {
        return player_health;
    }

	void Explosion() {
		//bang.GetComponent<explosion>().ExFire();
	}
	void Print() {
		
		winner_image.gameObject.SetActive(true);

		SoundManager.instance.PlaySound(7);
		winner_image.sprite = winner;
		countStarter.off();
	}
    
}
