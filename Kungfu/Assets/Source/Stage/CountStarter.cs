﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountStarter : MonoBehaviour {
    public Image ready, go;
    public GameObject player1, player2;
    float readyTime = 0f, startTime = 0f;
	// Use this for initialization
	void Start () {
        ready.gameObject.SetActive(true);
        go.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (readyTime >= 2.5f)
        {
            if (ready != null)
            {
                Destroy(ready);
                go.gameObject.SetActive(true);
            }
        }
        if (startTime >= 3.3f)
        {
            Destroy(go);
            player1.GetComponent<Character>().isStart = true;
            player2.GetComponent<Character>().isStart = true;

        }
        readyTime += Time.deltaTime;
        startTime += Time.deltaTime;
    }

    public void off() {
        player1.GetComponent<Character>().isStart = true;
        player2.GetComponent<Character>().isStart = true;
        Invoke("ChangeScene", 2);
    }

    void ChangeScene() {
        Application.LoadLevel("LoadingScene");
    }
}
