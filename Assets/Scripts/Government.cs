using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Government : MonoBehaviour
{
    public float amtOfMoney;
    public float revenuePerDay;
    public float taxRate;
    //public float incomeTax;
    //public float pstTax;
    //public float gstTax;
    private List<Shop> shops;
    private WorldManager wManager;

    private void Awake()
    {
        //incomeTax = 0.20f;
        //pstTax = 0.05f;
        //gstTax = 0.07f;
        wManager = FindObjectOfType<WorldManager>().GetComponent<WorldManager>();
        shops = new List<Shop>();
    }

    private void Start()
    {
        shops = wManager.shops;
        revenuePerDay = GetRevenuePerDay();
        //Debug.Log(revenuePerDay);
    }

    public void SpendMoney(float amount)
    {
        amtOfMoney -= amount;
        wManager.governmentSpending += amount;
        wManager.UpdateGDP();
    }

    private float GetRevenuePerDay()
    {
        float count = 0;
        foreach(Shop shop in shops)
        {
            count += shop.revenuePerDay * taxRate;
        }

        return count;
    }
}
