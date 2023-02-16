using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    //  프리챕 보관 변수
    public GameObject[] prefabs;

    //  풀 담당을 하는 리스트
    List<GameObject>[] pools;
    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];   

        for(int index = 0; index < pools.Length; index++)
            pools[index] = new List<GameObject>();
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        //  선택한 Pool의 놀고 있는 게임오브젝트 접근
            // 발견하면 select 변수에 할당

        foreach(GameObject pool in pools[index])
            if(!pool.activeSelf)
            {
                select = pool;
                select.SetActive(true);
                break;
            }

        if(!select)
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select); 
        }
        // 못 찾음면 
            // 새롭게 생성 select 변수에 할당

        return select;
    }
}
