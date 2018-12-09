using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class merterialMovement : MonoBehaviour {
    Rigidbody _rb;
    public float _ownGravity = 0.3f;
	// Use this for initialization
    void Awake()
    {
        _rb = this.GetComponent<Rigidbody>();
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        _rb.velocity = new Vector3(_rb.velocity.x, _rb.velocity.y - _ownGravity * Time.deltaTime, _rb.velocity.z);
	}
}
