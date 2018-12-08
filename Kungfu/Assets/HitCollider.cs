using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollider : MonoBehaviour {
    public float damage = 10.0f;
    public bool isAttack = false;

    
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

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
        if(isAttack && (col.tag=="Player"|| col.name=="ForeArm" || col.name=="UpperArm") )
        {
            isAttack = false;
            
            col.gameObject.GetComponent<HpManager>().DamageInit();
        }
    }
}
