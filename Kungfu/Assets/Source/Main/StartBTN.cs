using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartBTN : MonoBehaviour {
    float changeTimer = 0f;
    public Sprite[] image= new Sprite[2];
    int now = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (changeTimer > 0.35f)
        {

            gameObject.GetComponent<Image>().sprite = image[now % 2];
            now++;
            changeTimer = 0f;
        }
        changeTimer += Time.deltaTime;
    }
}
