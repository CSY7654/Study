using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public int pen;

    public void Init(float damage, int pen)
    {
        this.damage = damage;
        this.pen = pen;
    }
}
