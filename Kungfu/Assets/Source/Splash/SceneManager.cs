using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {
    float time = 0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (time >= 0.5f) {
            Application.LoadLevel("MainScene");
        }
        time += Time.deltaTime;
    }
}
