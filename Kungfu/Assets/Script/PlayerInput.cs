using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    Animator anim;

    public HitCollider middle;
    public HitCollider down;
    public HitCollider upper;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update() {
        
        
        if (Input.GetAxis("Horizontal") != 0)
        {
            anim.SetBool("wk", true);
        }
        else
        {
            anim.SetBool("wk", false);
        }

        if (tag == "1P")
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                // 상공격
                anim.SetTrigger("isKickingUpper");
                // 코루틴
            }

            if(Input.GetKeyDown(KeyCode.Keypad2))
            {
                // 중공격
                anim.SetTrigger("isPunching");
                // TODO 코루틴
            }

            if(Input.GetKeyDown(KeyCode.Keypad3))
            {
                // 하공격
            }
        } 
        else
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                anim.SetTrigger("kk");
                // 상공격
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                // 중공격
                anim.SetTrigger("pc");
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                // 하공격
                anim.SetTrigger("dk");
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                anim.SetTrigger("jp");
            }
        }
	}
    
    public void OnMiddle()
    {
        middle.OnAttack();
    }

    public void OffMiddle()
    {
        middle.OffAttack();
    }
}
