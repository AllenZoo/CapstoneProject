using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : MonoBehaviour
{
    public string citizenName;
    public float amtOfMoney;
    public List<Item> desiredItems;

    private void Awake()
    {
        desiredItems = new List<Item>();
    }

    public void AddDesiredItem(Item item)
    {
        desiredItems.Add(item);
    }
}
