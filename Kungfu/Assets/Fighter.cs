using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour {
    public Rigidbody rdbd;
    public PlayerInput playerInput;
	// Use this for initialization
	void Start () {
        rdbd = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
