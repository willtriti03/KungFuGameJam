using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSoundManager : MonoBehaviour {

    public AudioClip soundExplosion;    //사운드 파일을 가진다
    public static MainSoundManager instance;//사운드매니저의 위치를 담는다

    AudioSource audio;                  //오디오 소스 컨퍼넌트를 담을준비를 한다.
    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();// 오디오 컴퍼넌스를 담는다.
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Awake()
    {
        if (MainSoundManager.instance == null)
        {// 인스턴스가 비어있으면
            MainSoundManager.instance = this;   //이것의 인스턴스를 집어넣는다.
        }
    }

    public void PlaySound()
    {               //외부에서 소리출력을 위한 퍼블릭함수
        audio.PlayOneShot(soundExplosion);  //소리를 출력한ㄷㅏ.
    }
}
