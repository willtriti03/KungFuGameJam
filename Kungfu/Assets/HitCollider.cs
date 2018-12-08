using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollider : MonoBehaviour {
    public float damage = 10.0f;
    public bool isAttack = false;

    public bool damaged = false;

    [SerializeField]
    string[] parts;

    public void OnAttack()
    {
        isAttack = true;
    }

    public void OffAttack()
    {
        isAttack = false;
    }

    private void OnTriggerEnter(Collider col)
    {
        if(isAttack && ( col.name=="Body") )
        {
            Debug.Log("Called");
            isAttack = false;
            damaged = true;
        }
    }
}
