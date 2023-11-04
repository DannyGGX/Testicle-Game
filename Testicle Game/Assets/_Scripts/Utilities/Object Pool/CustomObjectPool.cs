using System.Collections.Generic;
using UnityEngine;

public class CustomObjectPool<T> where T : MonoBehaviour
{
    private Queue<T> availableObjects;
    private T prefab;
    
    public int PoolSize;
    public bool IsPoolSizeCapped;

    private Transform parentObject;
    
    public CustomObjectPool(T prefab, Transform parentObject, int initialSize, bool isPoolSizeCapped = false)
    {
        this.prefab = prefab;
        this.parentObject = parentObject;
        PoolSize = initialSize;
        this.IsPoolSizeCapped = isPoolSizeCapped;
        availableObjects = new Queue<T>();
        
        for (int i = 0; i < initialSize; i++)
        {
            T obj = GameObject.Instantiate(prefab, this.parentObject);
            obj.gameObject.SetActive(false);
            availableObjects.Enqueue(obj);
        }
    }

    public T SpawnObject()
    {
        if (availableObjects.Count == 0)
        {
            if (IsPoolSizeCapped)
                return null;
            
            T obj = GameObject.Instantiate(prefab, parentObject);
            obj.gameObject.SetActive(true);
            PoolSize++;
            return obj;
        }

        T pooledObject = availableObjects.Dequeue();
        pooledObject.gameObject.SetActive(true);
        return pooledObject;
    }
    
    public T SpawnObject(Vector3 position, Quaternion rotation)
    {
        if (availableObjects.Count == 0)
        {
            if (IsPoolSizeCapped)
                return null;
            
            T obj = GameObject.Instantiate(prefab, position, rotation, parentObject);
            obj.gameObject.SetActive(true);
            PoolSize++;
            return obj;
        }

        T pooledObject = availableObjects.Dequeue();
        pooledObject.gameObject.SetActive(true);
        Transform objectTransform = pooledObject.gameObject.transform;
        objectTransform.position = position;
        objectTransform.rotation = rotation;
        return pooledObject;
    }

    public void ReturnObject(T obj)
    {
        obj.gameObject.SetActive(false);
        availableObjects.Enqueue(obj);
    }
}