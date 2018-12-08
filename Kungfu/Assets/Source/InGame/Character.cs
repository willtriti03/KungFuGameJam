using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GageManager myGage;
    public GageManager enemyGage;
    public int lookingSide;
    public float jumpPower;
    public KeyCode[] code = new KeyCode[3];
    public Transform tr;
    public GameObject enemy;
    public bool isStart = false;

    private Rigidbody rigid;
    private bool m_jumping = false;
    public bool isAttack = false;
    private bool isTimer = false;
    private float speed = 10f;
    private float delay;
    public float curTime;

    public Animator anim;
    [SerializeField]
    private HitCollider upper;
    [SerializeField]
    private HitCollider middle;
    [SerializeField]
    private HitCollider down;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(myGage.GetPlayerHealth()<1f)
        {
            anim.SetBool("gg", true);
        }

        if(upper.damaged || middle.damaged || down.damaged)
        {
            upper.damaged = false;
            middle.damaged = false;
            down.damaged = false;
            enemyGage.DamagePlayer(10);
            enemy.GetComponent<Character>().anim.SetTrigger("dm");

        }

        if (isTimer) {
            curTime += Time.deltaTime;
            if (curTime >= delay) {
                isAttack = false;
                isTimer = false;
                curTime = 0;
                delay = 0;
            }
        }
        if (isStart)
        {
            MoveControll();
            TurnAround();
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            m_jumping = false;
        }
  


    }

    void MoveControll()
    {
        if (Input.GetKey(code[0])) {
            MoveLeft();
        }
        if (Input.GetKey(code[1])) {
            MoveRight();
        }
        if (Input.GetKeyUp(code[2])) {
           
            switch ((int)Random.Range(0,4)) {
                case 0:
                    JumpAttack();
                    break;
                case 1:
                    TopAttack();
                    break;
                case 2:
                    MiddleAttack();
                    break;
                case 3:
                    BottomAttack();
                    break;
            }
        }
        if (Input.GetKeyUp(code[0])||(Input.GetKeyUp(code[1])))
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            if (lookingSide == -1)
            {
                anim.SetBool("wk", false);
                anim.SetBool("wk_bk", false);
            }
            else
            {
                anim.SetBool("wk", false);
                anim.SetBool("wk_bk", false);
            }

        }

    }

    void MoveLeft() {
        gameObject.GetComponent<Rigidbody>().MovePosition(transform.position + (Vector3.left * speed * Time.deltaTime));

        if (!isAttack)
        {
            if (lookingSide == -1)
            {
                anim.SetBool("wk", true);
            }
            else
            {
                anim.SetBool("wk_bk", true);
            }
        }
    }

    void MoveRight() {
        gameObject.GetComponent<Rigidbody>().MovePosition(transform.position - (Vector3.left * speed * Time.deltaTime));

        if (lookingSide == 1)
        {
            anim.SetBool("wk", true); 
        }
        else
        {
            anim.SetBool("wk_bk", true);
        }
    }
    void JumpAttack() {
        if (!isAttack)
        {
            isAttack = true;
            rigid.AddForce(Vector3.up * jumpPower);
            anim.SetTrigger("jk");
            DelayAttack(0.4f);
            m_jumping = true;
        }
    }
    void TopAttack() {
        if (!isAttack) {
            isAttack = true;
            anim.SetTrigger("ta");
            DelayAttack(0.4f);
        }
    }
    void MiddleAttack()
    {
        if (!isAttack) {
            isAttack = true;
            anim.SetTrigger("ma");
            DelayAttack(0.4f);
        }
    }
    void BottomAttack() {
        if (!isAttack) {
            isAttack = true;
            anim.SetTrigger("ba");
            DelayAttack(0.4f);
        }
    }

    void DelayAttack(float delay)
    {
        this.delay = delay;
        isTimer = true;
    }

    void TurnAround() {
        if (lookingSide == 1)
        {
            if (enemy.transform.position.x < transform.position.x)
            {
                transform.Rotate(new Vector3(0, -180, 0));
                lookingSide *= -1;
            }
        }
        else
        {
            if (enemy.transform.position.x > transform.position.x)
            {
                transform.Rotate(new Vector3(0, -180, 0));
                lookingSide *= -1;
            }
        }
       
    }

    public void OnUpper()
    {
        upper.OnAttack();
    }

    public void OffUpper()
    {
        upper.OffAttack();
    }

    public void OnMiddle()
    {
        middle.OnAttack();
    }

    public void OffMiddle()
    {
        middle.OffAttack();
    }

    public void OnDown()
    {
        down.OnAttack();
    }

    public void OffDown()
    {
        down.OffAttack();
    }
}
