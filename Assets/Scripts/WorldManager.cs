using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public ItemDatabase itemDatabase;
    public List<GameObject> citizenSpawnArea;
    public GameObject citizenParent;
    public List<Citizen> population;
    public List<Shop> shops;
    public List<float> gdpData;
    public float GDP;
    public float dayCount;

    public float consumerSpending;
    public float governmentSpending;
    public float businessInvestments;
    public float exports;
    public float imports;

    public List<GameObject> citizenTemplate;

    private GraphManager gManager;
    private void Awake()
    {
        gManager = FindObjectOfType<GraphManager>().GetComponent<GraphManager>();
        population = new List<Citizen>();
        shops = new List<Shop>();

        Citizen[] tempPopulationList = FindObjectsOfType<Citizen>();
        for(int i = 0; i < tempPopulationList.Length; i++)
        {
            population.Add(tempPopulationList[i]);
        }

        Shop[] tempShopList = FindObjectsOfType<Shop>();
        for(int i = 0; i < tempShopList.Length; i++)
        {
            shops.Add(tempShopList[i]);
        }

    }

    private void Start()
    {
        foreach(Shop shop in shops)
        {
            businessInvestments += shop.amtOfMoney;
        }

        foreach(Citizen citizen in population)
        {
            foreach(Item item in citizen.desiredItems)
            {
                consumerSpending += item.eqPrice;
                citizen.amtOfMoney -= item.eqPrice;
            }
        }

        GDP += governmentSpending;

        UpdateGDP();
    }

    public void GenerateCitizen()
    {
        GameObject tempCitizen = Instantiate(citizenTemplate[Random.Range(0, citizenTemplate.Count)], citizenParent.transform);
        tempCitizen.transform.position = citizenSpawnArea[Random.Range(0, citizenSpawnArea.Count)].transform.position;

        tempCitizen.GetComponent<Citizen>().amtOfMoney = GetRandomNum();
        tempCitizen.GetComponent<Citizen>().citizenName = GetRandomName();
        tempCitizen.GetComponent<Citizen>().desiredItems = GetRandomListOfItems();
    }
    
    private List<Item> GetRandomListOfItems()
    {
        return new List<Item>() { itemDatabase.GetRandomItem() };
    }

    private float GetRandomNum()
    {
        return Random.Range(300, 1000);
    }
    private string GetRandomName()
    {
        int ranNum = Random.Range(0, 7);

        switch (ranNum)
        {
            default:
                return "George";
            case 1: return "Bobby";
            case 2: return "Stewart";
            case 3: return "Roger";
            case 4: return "Annabell";
            case 5: return "Luna";
            case 6: return "Joe";
        }
    }

    public Shop GetShopByString(string name)
    {
        foreach(Shop shop in shops)
        {
            if (shop.name.Equals(name))
            {
                return shop;
            }
        }
        return null;
    }

    public void CalculateGDP()
    {
        GDP = consumerSpending + governmentSpending + businessInvestments + (exports - imports);
        gdpData.Add(GDP);
    }

    public void UpdateGDP()
    {
        GDP = consumerSpending + governmentSpending + businessInvestments + (exports - imports);
        Debug.Log("GDP: " + GDP);
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.I))
    //    {
    //        gManager.ShiftDGraph(5);
    //    }
    //    else if (Input.GetKeyDown(KeyCode.O))
    //    {
    //        gManager.ShiftDGraph(-5);
    //    }
    //}
}
