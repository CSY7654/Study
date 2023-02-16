using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 vec2;
    Rigidbody2D rigid;

    [SerializeField]
    public float speed = 1f;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Vector2 nextvec = vec2 * speed * Time.deltaTime;
        rigid.MovePosition(rigid.position + nextvec);
    }

    void OnMove(InputValue value)
    {
        vec2 = value.Get<Vector2>();
    }

}
