using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    public PoolManager poolManager;
    public Player player;

    public void Awake()
    {
        instance = this; 
    }
}
