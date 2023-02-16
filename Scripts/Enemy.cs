using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealthPoint;
    public float HealthPoint;
    public float damage;

    public float speed;

    bool isLIve;

    Vector2 vec;
    Rigidbody2D rigid;
    public Rigidbody2D target;

    public void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        maxHealthPoint = 50;
        HealthPoint = maxHealthPoint;
        damage = 10;
        speed = 1.5f;
    }

    private void FixedUpdate()
    {
        if (!isLIve)
            return;
        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.deltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;
    }

    public void OnEnable()
    {
        target = Gamemanager.instance.player.GetComponent<Rigidbody2D>();
        isLIve = true;
        HealthPoint = maxHealthPoint;
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            HealthPoint -= collision.GetComponent<Bullet>().damage;
            Debug.Log($"HP: {HealthPoint}");
        }
        if (HealthPoint <= 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        gameObject.SetActive(false);
    }

    public void Init(spawnDate data)
    {
        speed = data.speed;
        maxHealthPoint = data.health;
        HealthPoint = data.health; 
    }
}


