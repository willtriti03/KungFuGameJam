using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
    public int viewSide;
    public float speed = 0.1f;
    public float curTime = 0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        curTime += Time.deltaTime;
        if (curTime > 30f)
        {
        }
        else if (curTime>20) {
			if (ManagerScript.instance.gameEnd == true)
			{
				return;
			}
            transform.Translate(viewSide * Vector3.right * speed * Time.deltaTime);

        }
    }
}
