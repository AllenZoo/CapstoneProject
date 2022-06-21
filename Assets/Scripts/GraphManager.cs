using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphManager : MonoBehaviour
{
    public WorldManager wManager;
    public Window_Graph graph;
    public GameObject graphCloseButton;

    private ItemDatabase itemDatabase;
    private List<Citizen> population;
    private List<Shop> businesses;

    private Item itemRef;

    private void Awake()
    {
        wManager = FindObjectOfType<WorldManager>().GetComponent<WorldManager>();
        //graph = FindObjectOfType<Window_Graph>().GetComponent<Window_Graph>();

        population = new List<Citizen>();
        businesses = new List<Shop>();
        itemDatabase = new ItemDatabase();
    }

    private void Start()
    {
        population = wManager.population;
        businesses = wManager.shops;
        itemDatabase = wManager.itemDatabase;

        //Debug.Log("$ " +  itemDatabase.GetItem(Item.ItemType.Cake).supplyCurve[0][0]);
        //Debug.Log("$ " +  itemDatabase.GetItem(Item.ItemType.Cake).supplyCurve[1][0]);
        //Debug.Log("$" + itemDatabase.GetItem(Item.ItemType.Cake).supplyCurve[2][0]);
        //Debug.Log("$" + itemDatabase.GetItem(Item.ItemType.Cake).supplyCurve[3][0]);
        //Debug.Log("$" + itemDatabase.GetItem(Item.ItemType.Cake).supplyCurve[4][0]);
        //Debug.Log("$" + itemDatabase.GetItem(Item.ItemType.Cake).supplyCurve[5][0]);
        //Debug.Log("$" + itemDatabase.GetItem(Item.ItemType.Cake).supplyCurve[6][0]);

        //Debug.Log("Q" + itemDatabase.GetItem(Item.ItemType.Cake).supplyCurve[0][1]);
        //Debug.Log("Q" + itemDatabase.GetItem(Item.ItemType.Cake).supplyCurve[1][1]);
        //Debug.Log("Q" + itemDatabase.GetItem(Item.ItemType.Cake).supplyCurve[2][1]);
        //Debug.Log("Q"+ itemDatabase.GetItem(Item.ItemType.Cake).supplyCurve[3][1]);
        //Debug.Log("Q" + itemDatabase.GetItem(Item.ItemType.Cake).supplyCurve[4][1]);
        //Debug.Log("Q" + itemDatabase.GetItem(Item.ItemType.Cake).supplyCurve[5][1]);
        //Debug.Log("Q" + itemDatabase.GetItem(Item.ItemType.Cake).supplyCurve[6][1]);
        //Debug.Log(itemDatabase.GetItem(Item.ItemType.Cake).supplyCurve[7]);
    }

    public void DisplaySDGraph(Item.ItemType itemType)
    {
        graph.gameObject.SetActive(true);
        graphCloseButton.SetActive(true);
        DisplaySDGraph(itemDatabase.GetItem(itemType));
    }

    public void DisplaySDGraph(Item item)
    {
        itemRef = item;
        graph.gameObject.SetActive(true);
        graphCloseButton.SetActive(true);
        graph.ShowDSGraph(item);
    }
    public void ShiftDGraph(float amount)
    {
        foreach (List<float> cord in itemRef.demandCurve)
        {
            cord[0] += amount;
        }

        RefreshGraph();
    }

    public void ShiftSGraph( float amount)
    { 
        foreach (List<float> cord in itemRef.supplyCurve)
        {
            cord[0] += amount;
        }

        RefreshGraph();
    }

    private void RefreshGraph()
    {
        DisplaySDGraph(itemRef);
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.K))
    //    {
    //        Debug.Log("K pressed");
    //        ShiftGraphRight(itemRef.supplyCurve, 100);
    //        DisplaySDGraph(itemRef);
    //    }
    //}
}
