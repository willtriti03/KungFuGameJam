using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {
    public string scene;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Return))
		{
			NextScene();
		}
	}

    public void NextScene() {
        Application.LoadLevel(scene);
    }
}
