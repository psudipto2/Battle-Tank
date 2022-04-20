using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ObjectPooler<T> : MonoSingletonGeneric<ObjectPooler<T>> where T:class
{
    private List<ObjectToPool<T>> pooledItems;
    public virtual T GetItem()
    {
        if (pooledItems.Count > 0)
        {
            ObjectToPool<T> item = pooledItems.Find(i => i.IsUsed == false);
            if (item != null)
            {
                item.IsUsed = true;
                return item.Item;
            }
        }
        return CreateNewPooledItem();
    }

    private T CreateNewPooledItem()
    {
        ObjectToPool<T> pooledItem = new ObjectToPool<T>();
        pooledItem.Item = CreateItem();
        pooledItem.IsUsed = true;
        pooledItems.Add(pooledItem);
        return pooledItem.Item;
    }

    public virtual void ReturnItem(T item)
    {
        ObjectToPool<T> pooledItem = pooledItems.Find(i => i.Item.Equals(item));
        pooledItem.IsUsed = false;
    }
    protected virtual T CreateItem()
    {
        return (T)null;
    }
    [System.Serializable]
    private class ObjectToPool<T>
    {
        public T Item;
        public bool IsUsed;
    }
}
