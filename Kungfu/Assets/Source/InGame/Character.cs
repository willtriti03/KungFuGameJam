using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int lookingSide;
    public float jumpPower;
    public KeyCode[] code = new KeyCode[3];
    public Transform tr;
    public GameObject enemy;
    public bool isStart = false;

    private Rigidbody rigid;
    private bool m_jumping = false;
    private bool isAttack = false;
    private bool isTimer = false;
    private float speed = 10f;
    private float delay;
    private float curTime;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
       
    }

    // Update is called once per frame
    void Update()
    {
       
        if (isTimer) {
            curTime += Time.deltaTime;
            if (curTime == delay) {
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
        if (Input.GetKey(code[2])) {
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


        }

    }

    void MoveLeft() {
        transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        //gameObject.GetComponent<Rigidbody>().velocity = new Vector3( -speed ,0,0);
    }

    void MoveRight() {
        //gameObject.GetComponent<Rigidbody>().velocity = new Vector3(speed , 0, 0);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }
    void JumpAttack() {
        if (!isAttack)
        {
            isAttack = true;
            rigid.AddForce(Vector3.up * jumpPower);
            //애니메이션 ㄲㄲ
            DelayAttack(0.8f);
            m_jumping = true;
        }
    }
    void TopAttack() {
        if (!isAttack) {
            isAttack = true;
            //애니메이션 ㄲㄲ
            DelayAttack(0.8f);
        }
    }
    void MiddleAttack()
    {
        if (!isAttack) {
            isAttack = true;
            //애니메이션 ㄲㄲ
            DelayAttack(0.8f);
        }
    }
    void BottomAttack() {
        if (!isAttack) {
            isAttack = true;
            //애니메이션 ㄲㄲ
            DelayAttack(0.8f);
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

}
