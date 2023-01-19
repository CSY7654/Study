using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Units;
[RequireComponent(typeof(Rigidbody2D))]
public class Player : Unit
{
    bool isDead = false;

    Vector2 inputVec;       // ���ͼ���

    SpriteRenderer spriteRenderer;      // ��������Ʈ����
    Animator anim;      // ���ϸ��̼Ǽ���

    Rigidbody2D rigid;      // ������ٵ𼱾�

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();        // ��������Ʈ ������Ʈ ��������
        anim = GetComponent<Animator>();        // ���ϸ��̼� ������Ʈ �������� 
        rigid = GetComponent<Rigidbody2D>();        // ������ٵ� ������Ʈ ��������
    }

    public void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");        // X�� ���� �ε巯�� ������(GetAxisRaw)
        inputVec.y = Input.GetAxisRaw("Vertical");      // Y�� ���� �ε巯�� ������(GetAxisRaw)

    }

    public void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * Speed * Time.fixedDeltaTime;        // �������� ���ư����� ����    
        rigid.MovePosition(rigid.position + nextVec);       // ��ġ �̵� ���
    }

    public void LateUpdate()
    {
        if (Input.GetKey("d"))      // �����U(D)�̵� X�� ��������Ʈ�ø� Ȱ��ȭ
        {
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKey("a"))     // ����(A)�̵� X�� ��������Ʈ�ø� ����
        {
            spriteRenderer.flipX = false;
        }

        anim.SetFloat("speed", inputVec.magnitude);    
    }

    private  void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Enemy" && !isDamage)
        {
            isDamage = true;
            float enemyAttack = collision.gameObject.GetComponent<Monster>().Damage;
            currentHp -= enemyAttack;
            if(currentHp <= 0)
            {
                isDead = true;
                gameObject.SetActive(false);
            }
        }
    }

}
