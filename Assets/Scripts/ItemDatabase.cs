using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Asset/Item Database")]
public class ItemDatabase : ScriptableObject
{ 
    public List<Item> items;

    public Item GetItem(Item.ItemType itemType)
    {
        foreach(Item _item in items)
        {
            if (_item.itemType.Equals(itemType))
            {
                return _item;
            }
        }
        return null;
    }

    public Item GetRandomItem()
    {
        int randomNum = Random.Range(0, items.Count);
        return items[randomNum];
    }
}
