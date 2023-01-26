using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Units;
public class Monster : Unit
{
    public Rigidbody2D target;
    SpriteRenderer spriter;
    Rigidbody2D rigid;

    bool isLive = true;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (!isLive)
            return;

        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * Speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;
    }

    private void LateUpdate()
    {
        spriter.flipX = target.position.x > rigid.position.x; 
    }

    private void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
    }
}