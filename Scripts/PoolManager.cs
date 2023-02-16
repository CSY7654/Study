using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    //  ����é ���� ����
    public GameObject[] prefabs;

    //  Ǯ ����� �ϴ� ����Ʈ
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

        //  ������ Pool�� ��� �ִ� ���ӿ�����Ʈ ����
            // �߰��ϸ� select ������ �Ҵ�

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
        // �� ã���� 
            // ���Ӱ� ���� select ������ �Ҵ�

        return select;
    }
}
