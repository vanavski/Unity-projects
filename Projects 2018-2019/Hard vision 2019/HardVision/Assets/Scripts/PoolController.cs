using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PoolItem
{
    public int amount;
    public GameObject poolObject;
    public bool shouldExpand;
}

public class PoolController : MonoBehaviour
{
    public static PoolController SharedInstance;
    public List<GameObject> pooledObjects;
    public List<PoolItem> itemsToPool;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        foreach (var item in itemsToPool)
        {
            for (var i = 0; i < item.amount; i++)
            {
                var pObject = Instantiate(item.poolObject);
                pObject.SetActive(false);
                pooledObjects.Add(pObject);
            }
        }
    }

    public GameObject GetPooledObject(string tag)
    {
        foreach (var obj in pooledObjects)
        {
            if (!obj.activeInHierarchy && obj.tag == tag)
            {
                return obj;
            }
        }

        foreach (var item in itemsToPool)
        {
            if (item.poolObject.tag == tag)
            {
                if (item.shouldExpand)
                {
                    var obj = Instantiate(item.poolObject);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    return obj;
                }
            }
        }
        return null;
    }
}