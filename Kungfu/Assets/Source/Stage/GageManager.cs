using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GageManager : MonoBehaviour {
    public Image player_gage;

    public float player_health = 100f;


    float full_damage = 0f,damage=0;
    float cal = 100f;
    public float speed = 100f;
   
    public bool test = false;

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
        else if (full_damage == damage && damage != 0)
        {
            full_damage = 0;
            damage = 0;
        }

      

    }
    public void DamagePlayer(int damage) {
        this.damage += damage;
        cal -= damage;
    }

    
}
