using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour {

	public static ManagerScript instance = null;

	public bool gameEnd = false;

	void Awake()
	{
		if (instance == null)
			instance = this;

		else if (instance != this)
			Destroy(gameObject);

	}
}
