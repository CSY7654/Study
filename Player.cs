using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Units;
[RequireComponent(typeof(Rigidbody2D))]
public class Player : Unit
{
    bool isDead = false;

    Vector2 inputVec;       // 벡터선언

    SpriteRenderer spriteRenderer;      // 스프라이트선언
    Animator anim;      // 에니메이션선언

    Rigidbody2D rigid;      // 리지드바디선언

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();        // 스프라이트 컴포넌트 가져오기
        anim = GetComponent<Animator>();        // 에니메이션 컴포넌트 가져오기 
        rigid = GetComponent<Rigidbody2D>();        // 리지드바디 컴포넌트 가져오기
    }

    public void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");        // X축 벡터 부드러운 움직임(GetAxisRaw)
        inputVec.y = Input.GetAxisRaw("Vertical");      // Y축 벡터 부드러운 움직임(GetAxisRaw)

    }

    public void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * Speed * Time.fixedDeltaTime;        // 다음으로 나아가야할 방향    
        rigid.MovePosition(rigid.position + nextVec);       // 위치 이동 방식
    }

    public void LateUpdate()
    {
        if (Input.GetKey("d"))      // 오른쪾(D)이동 X축 스프라이트플립 활성화
        {
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKey("a"))     // 왼쪽(A)이동 X축 스프라이트플립 해제
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
