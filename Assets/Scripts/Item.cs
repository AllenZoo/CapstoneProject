using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Asset/Item")]
public class Item : ScriptableObject
{
    public ItemType itemType;

    //Base Demand Curve
    public List<List<float>> demandCurve;
    public float elasticityOfDemand;

    //Base Supply Curve
    public List<List<float>> supplyCurve;
    public float elasticityOfSupply;

    public float eqPrice;
    public float eqQuantity;

    private void OnEnable()
    {
        //elasticityOfSupply *= 100;
        //elasticityOfDemand *= 100;

        demandCurve = new List<List<float>>(){
            new List<float>() { elasticityOfDemand * (eqPrice - eqPrice * 7 / 10) / eqPrice * 100 / 100 + eqQuantity, eqPrice * 7/10 },
            new List<float>() { elasticityOfDemand * (eqPrice - eqPrice * 8 / 10) / eqPrice * 100 / 100 + eqQuantity, eqPrice * 8/10 },
            new List<float>() { elasticityOfDemand * (eqPrice - eqPrice * 9 / 10) / eqPrice * 100 / 100 + eqQuantity, eqPrice * 9/10 },
            new List<float>() { eqQuantity, eqPrice },
            new List<float>() { elasticityOfDemand * (eqPrice - eqPrice * 11 / 10) / eqPrice * 100 / 100 + eqQuantity, eqPrice * 11/10 },
            new List<float>() { elasticityOfDemand * (eqPrice - eqPrice * 12 / 10) / eqPrice * 100 / 100 + eqQuantity, eqPrice * 12/10 },
            new List<float>() { elasticityOfDemand * (eqPrice - eqPrice * 13 / 10) / eqPrice * 100 / 100 + eqQuantity, eqPrice * 13/10 },
        };

        supplyCurve = new List<List<float>>() {
            new List<float>() { elasticityOfSupply * (eqPrice - eqPrice * 13 / 10) / eqPrice * 100 / 100 + eqQuantity, eqPrice * 7/10 },
            new List<float>() { elasticityOfSupply * (eqPrice - eqPrice * 12 / 10) / eqPrice * 100 / 100 + eqQuantity, eqPrice * 8/10 },
            new List<float>() { elasticityOfSupply * (eqPrice - eqPrice * 11 / 10) / eqPrice * 100 / 100 + eqQuantity, eqPrice * 9/10 },
            new List<float>() { elasticityOfSupply * (eqPrice - eqPrice * 10 / 10) / eqPrice * 100 / 100 + eqQuantity, eqPrice},
            new List<float>() { elasticityOfSupply * (eqPrice - eqPrice * 9 / 10) / eqPrice * 100 / 100 + eqQuantity, eqPrice * 11/10 },
            new List<float>() { elasticityOfSupply * (eqPrice - eqPrice * 8 / 10) / eqPrice * 100 / 100 + eqQuantity, eqPrice * 12/10 },
            new List<float>() { elasticityOfSupply * (eqPrice - eqPrice * 7 / 10) / eqPrice * 100 / 100 + eqQuantity, eqPrice * 13/10 },
        };

    }

    public void ChangePrice()
    {
        Debug.Log("price changed: " + eqPrice);
    }

    
    public enum ItemType {
        Apple, 
        Cake,
        Clothes,
    }

}
