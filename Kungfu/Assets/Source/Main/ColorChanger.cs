using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour {
    float changeTimer = 0f;
    public Sprite[] image= new Sprite[3];
    int now = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if ( changeTimer > 0.07f)
        {
           
            gameObject.GetComponent<Image>().sprite = image[now % 3];
            now++;
            changeTimer = 0f;
        }
        changeTimer += Time.deltaTime;
    }
}
