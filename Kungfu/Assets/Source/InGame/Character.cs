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
	public bool isAttack = false;
	public bool isDamaged = false;
	private float speed = 7f;
	public float attSped;

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
		if (upper.damaged || middle.damaged || down.damaged)
		{
			upper.damaged = false;
			middle.damaged = false;
			down.damaged = false;
			enemyGage.DamagePlayer(10);
			SoundManager.instance.PlaySound(0);
			enemy.GetComponent<Character>().anim.SetTrigger("dm");
			enemy.GetComponent<Character>().isDamaged = true;
			enemy.GetComponent<Character>().isAttack = false;
		}

		if (isStart)
		{
			MoveControll();
			TurnAround();
		}
	}

	void MoveControll()
	{
		if (ManagerScript.instance.gameEnd == true)
		{
			return;
		}

		if (Input.GetKey(code[0]))
			MoveLeft();
		else
		{
			if (lookingSide == -1)
				anim.SetBool("wk", false);
			else
				anim.SetBool("wk_bk", false);
		}

		if (Input.GetKey(code[1]))
			MoveRight();
		else
		{
			if (lookingSide == 1)
				anim.SetBool("wk", false);
			else
				anim.SetBool("wk_bk", false);
		}

		if (Input.GetKeyUp(code[2]) && !isDamaged)
			switch ((int)Random.Range(0, 4))
			{
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

		if (isAttack)
		{
			anim.SetBool("wk", false);
			anim.SetBool("wk_bk", false);
		}
	}

	void MoveLeft()
	{
		gameObject.GetComponent<Rigidbody>().MovePosition(transform.position + (Vector3.left * speed * Time.deltaTime));

		if (!isDamaged && !isAttack)
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

	void MoveRight()
	{
		gameObject.GetComponent<Rigidbody>().MovePosition(transform.position - (Vector3.left * speed * Time.deltaTime));

		if (!isDamaged && !isAttack)
		{
			if (lookingSide == 1)
			{
				anim.SetBool("wk", true);
			}
			else
			{
				anim.SetBool("wk_bk", true);
			}
		}
	}
	void JumpAttack()
	{
		if (!isDamaged && !isAttack)
		{
			isAttack = true;
			anim.SetTrigger("jk");
		}
	}
	void TopAttack()
	{
		if (!isDamaged && !isAttack)
		{
			isAttack = true;
			anim.SetTrigger("ta");
		}
	}
	void MiddleAttack()
	{
		if (!isDamaged && !isAttack)
		{
			isAttack = true;
			anim.SetTrigger("ma");
		}
	}
	void BottomAttack()
	{
		if (!isDamaged && !isAttack)
		{
			isAttack = true;
			anim.SetTrigger("ba");
		}
	}

	void TurnAround()
	{
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

	public void endAttack()
	{
		isAttack = false;
	}

	public void endDamaged()
	{
		isDamaged = false;
	}
}