using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;

    float timer;

    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }
    private void Update()
    {
        timer += Time.deltaTime;

        if(timer > 1f)
        {
            //GameManager.instance.pool.Get(0); 이거 하나 때문에 4시간 날린듯
            timer = 0;
            Spawn();
        }

    }

    void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(0);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
    }
}
