using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public spawnDate[] spawndata;

    public Transform[] spawnPoint;

    float timer;

    public void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    public void Start()
    {
       
    }
    public void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2f)
        {
            Spawn();
            timer = 0f;
        }
    }

    public void Spawn()
    {
        GameObject enemy = Gamemanager.instance.poolManager.Get(0);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
    }
}
[System.Serializable]
public class spawnDate
{
    public int spriteType;
    public float spawnTime;
    public int health;
    public float speed;
}
