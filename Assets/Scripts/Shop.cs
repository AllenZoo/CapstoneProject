using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public string name;
    public Citizen owner;
    public List<Item> itemsBeingSold;
    public float amtOfMoney;

    public float maxMRPL;

    public float workerWage;
    public float variableCosts;
    public float fixedCosts;

    public float revenuePerDay;
    public float assetsValue;
    public float shareValue;

    private void Awake()
    {
        revenuePerDay = itemsBeingSold[0].eqQuantity * itemsBeingSold[0].eqPrice;
        //Debug.Log(revenuePerDay);
    }

    public void AddMoney(float money)
    {
        amtOfMoney += money;
    }

    public void SpendMoney(float money)
    {
        amtOfMoney -= money;
    }

    public void IncreaseVariableCost(float amt)
    {
        variableCosts += amt;
    }
}
