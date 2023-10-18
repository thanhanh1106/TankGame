using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : Singleton<ObjectPooler>
{
    [System.Serializable]
    public class Pool
    {
        public PoolMember Name;
        public GameObject Prefabs;
        public int InitialSize;
    }

    public List<Pool> Pools;
    Dictionary<PoolMember, Queue<GameObject>> poolDictionary;

    protected override void Awake()
    {
        MakeSingleton(true);
        poolDictionary = new Dictionary<PoolMember, Queue<GameObject>>();

        foreach (Pool pool in Pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int index = 0; index < pool.InitialSize; index++)
            {
                GameObject obj = Instantiate(pool.Prefabs);
                obj.SetActive(false);
                obj.transform.parent = transform;
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.Name, objectPool);
        }
    }

    public GameObject GetGameObjectFormPool(PoolMember memberName, Vector3 postion, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(memberName))
        {
            throw new MissingMemberException($"Pool with tag {tag} doesn't exit!");
        }

        GameObject objectToGet;
        // nếu còn game object trong pool thì lấy nó ra dùng bình thường 
        if (poolDictionary[memberName].Count > 0)
        {
            objectToGet = poolDictionary[memberName].Dequeue();
        }
        // nếu hết game object trong pool thì tạo nó ra
        else
        {
            objectToGet = Instantiate(GetPrefabsWithTag(memberName));
        }

        objectToGet.SetActive(true);
        objectToGet.transform.position = postion;
        objectToGet.transform.rotation = rotation;
        objectToGet.transform.parent = null;
        return objectToGet;
    }

    public void ReturnGameObjectToPool(PoolMember memberName, GameObject obj)
    {
        if (!poolDictionary.ContainsKey(memberName))
            throw new MissingMemberException($"Pool with tag {tag} doesn't exit!");
        obj.transform.parent = this.transform;
        obj.SetActive(false);

        poolDictionary[memberName].Enqueue(obj);
    }

    GameObject GetPrefabsWithTag(PoolMember memberName)
    {
        foreach (Pool pool in Pools)
        {
            if (pool.Name == memberName)
                return pool.Prefabs;
        }
        return null;
    }
}
