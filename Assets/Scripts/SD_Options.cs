using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SD_Options : MonoBehaviour
{
    [SerializeField] private GameObject buttonTemplate;
    private RectTransform buttonContainer;
    private WorldManager wManager;
    private GraphManager gManager;
    private ItemDatabase itemDatabase;
    private void Awake()
    {
        buttonContainer = transform.Find("buttonContainer").GetComponent<RectTransform>();
        wManager = FindObjectOfType<WorldManager>().GetComponent<WorldManager>();
        gManager = FindObjectOfType<GraphManager>().GetComponent<GraphManager>();
        itemDatabase = new ItemDatabase();
    }

    private void Start()
    {
        itemDatabase = wManager.itemDatabase;
        GenerateButtons();
    }

    private void GenerateButtons()
    {
        float containerWidth = buttonContainer.sizeDelta.x;
        float containerHeight = buttonContainer.sizeDelta.y;
        float x = 0 - containerWidth/2;
        float y = -15 + containerHeight/4;
        foreach(Item item in itemDatabase.items)
        {
            GameObject gameObject = Instantiate(buttonTemplate);
            gameObject.transform.SetParent(buttonContainer);
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
            gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            gameObject.transform.Find("Text").GetComponent<Text>().text = item.itemType.ToString();
            y += 25;

            if(y > containerHeight)
            {
                y = -15 + containerHeight / 4;
                x += 50;
            }
        }
    }

    public void ButtonClicked(Item.ItemType itemType)
    {
        gManager.DisplaySDGraph(itemType);
    }
}
