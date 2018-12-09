using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

	public AudioClip[] damageSounds;
	public static SoundManager instance;

	[SerializeField]
	AudioSource audio;

	void Awake()
	{
		if(SoundManager.instance==null)
		{
			SoundManager.instance = this;
		}
	}

	public void PlaySound(int index)
	{
		audio.PlayOneShot(damageSounds[index]);

	}
}
