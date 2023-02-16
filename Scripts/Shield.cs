using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public int id;
    public int prefabId;
   
    public int count;
    public float speed;
    public float damage;


    public void Start()
    {
        Init();
    }

    public void Update()
    {
        switch (id)
        {
            case 0:
                transform.Rotate(Vector3.back * speed * Time.deltaTime);
                break;
            default:
                break;
        }
        // test
        if(Input.GetButtonDown("Jump"))
        {
            LevelUp(20, 5);
        }
    }

    public void LevelUp(float damage, int count)
    {
        this.damage = damage;
        this.count += count;

        if(id == 0)
            Batch();
    }
    public void Init()
    {
        switch (id)
        {
            case 0:
                speed = -150;
                Batch();
                break;
            default:
                break;
        }

    }
    public void Batch()
    {
        for (int index =0;index<count; index++)
        {
            Transform rotateWeap;
            if (index < transform.childCount)
            {
                rotateWeap = transform.GetChild(index); 
            }
            else
            {
                rotateWeap = Gamemanager.instance.poolManager.Get(prefabId).transform;
                rotateWeap.parent = transform;
            }

            rotateWeap.localPosition = Vector3.zero;
            rotateWeap.localRotation = Quaternion.identity;

            Vector3 roVec = Vector3.forward * 360 * index / count;
            rotateWeap.Rotate(roVec);
            rotateWeap.Translate(rotateWeap.up * 1.5f, Space.World);

            rotateWeap.GetComponent<Bullet>().Init(damage, -1); // -1 is infinity pen
        }
    }
}
