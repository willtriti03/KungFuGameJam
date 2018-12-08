using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GageManager : MonoBehaviour {
    public Image player1_gage;
    public Image player2_gage;

    public float player1_health = 100f;
    public float player2_health = 100f;

    float full_damage1 = 0f,damage1=0;
    float full_damage2 = 0f, damage2=0;
    float cal1=100f, cal2=100f;
    public float speed = 100f;
   
    public bool test = false;

	// Use this for initialization
	void Start () {
        player1_gage.GetComponent<Image>().fillAmount = player1_health / 100f;
        player2_gage.GetComponent<Image>().fillAmount = player2_health / 100f;

    }

    // Update is called once per frame
    void Update () {
        if (test) {
            DamagePlayer1(30);
            DamagePlayer2(30);

            test = false;
        }
        if (player1_health < cal1) {
            player1_gage.GetComponent<Image>().fillAmount = (cal1) / 100f;
            player1_health = cal1;
            full_damage1 = 0;
            damage1 = 0;
        }
        else if (full_damage1 != damage1 && damage1 != 0)
        {
            full_damage1 += Time.deltaTime * speed;
            player1_health -= Time.deltaTime * speed;
            player1_gage.GetComponent<Image>().fillAmount = (player1_health) / 100f;

        }
        else if (full_damage1 == damage1 && damage1 != 0)
        {
            full_damage1 = 0;
            damage1 = 0;
        }

        //////////////////////////////////////////////////////////////////////////////////////////
        if (player2_health < cal2)
        {
            player2_gage.GetComponent<Image>().fillAmount = (cal2) / 100f;
            player2_health = cal2;
            full_damage2 = 0;
            damage2 = 0;
        }
        else if (full_damage2 != damage2 && damage2 != 0)
        {
            full_damage2 += Time.deltaTime * speed;
            player2_health -= Time.deltaTime * speed;
            player2_gage.GetComponent<Image>().fillAmount = (player2_health) / 100f;

        }
        else if (full_damage2 == damage2 && damage2 != 0)
        {
            full_damage2 = 0;
            damage2 = 0;
        }

    }
    public void DamagePlayer1(int damage) {
        damage1 += damage;
        cal1 -= damage;
    }

    public void DamagePlayer2(int damage)
    {
        damage2 += damage;
        cal2 -= damage;
    }
}
