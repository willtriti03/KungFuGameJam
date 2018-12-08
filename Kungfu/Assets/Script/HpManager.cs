using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpManager : MonoBehaviour {

    [SerializeField]
    private int hp = 100;

    public void DamageInit()
    {
        hp -= 10;
    }

}
