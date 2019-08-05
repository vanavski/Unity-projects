using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    #region Singleton
    public static InventoryController instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found");
            return;
        }

        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallBack;

    public int Size = 5;

    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= Size)
            {
                Debug.Log("Not enough space");
                return false;
            }
            items.Add(item);

            OnItemChangedCallBack?.Invoke();
        }
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        OnItemChangedCallBack?.Invoke();
    }
}