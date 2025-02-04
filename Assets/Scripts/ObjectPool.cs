using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    GameObject obj;
    List<GameObject> pool;
    int initialCount;

    int nextCount;

    public ObjectPool(GameObject obj, int initialCount)
    {
        nextCount = 0;
        this.obj = obj;
        this.pool = new List<GameObject>();
        this.initialCount = initialCount;

        for(int i = 0; i < initialCount; i++)
        {
            GameObject curr = GameObject.Instantiate(this.obj);
            curr.SetActive(false);
            pool.Add(curr);
        }
    }

    public GameObject GetObject()
    {
        while(pool[nextCount].activeSelf == true)
        {
            nextCount = (nextCount + 1) % initialCount;
        }
        return pool[nextCount];
    }

    public int Size()
    {
        return pool.Count;
    }

    public int NumActive()
    {
        int count = 0;
        for(int i = 0; i < pool.Count; i++)
        {
            if (pool[i].activeSelf)
            {
                count++;
            }
        }
        return count;
    }
}
