using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float maxHealthPoint;
    [SerializeField]
    float HealthPoint;
    float atkSpeed;

    Rigidbody2D rigid;


    public void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        maxHealthPoint = 100;
        HealthPoint = maxHealthPoint;
       
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Enemy"))
        {
            HealthPoint -= collision.collider.GetComponent<Enemy>().damage;
            Debug.Log($"HP: {HealthPoint}");

        }

        if (HealthPoint == 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        gameObject.SetActive(false);
    }

}
