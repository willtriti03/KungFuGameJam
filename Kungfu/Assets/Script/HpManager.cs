using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpManager : MonoBehaviour {

    [SerializeField]
    private int hp = 100;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void DamageInit()
    {
        Debug.Log("Called");
        hp -= 10;
        anim.SetTrigger("dm");
    }

}
