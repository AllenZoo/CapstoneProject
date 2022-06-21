using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Window_Graph : MonoBehaviour
{
    [SerializeField] private Sprite pointSprite;
    private RectTransform graphContainer;
    private RectTransform labelTemplateX;
    private RectTransform labelTemplateY;
    private RectTransform dashTemplateX;
    private RectTransform dashTemplateY;

    private Text xAxisText;
    private Text yAxisText;
    private Text titleText;

    private List<GameObject> gameObjectList;


    private void Awake()
    {
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        labelTemplateX = graphContainer.Find("labelTemplateX").GetComponent<RectTransform>();
        labelTemplateY = graphContainer.Find("labelTemplateY").GetComponent<RectTransform>();
        dashTemplateX = graphContainer.Find("dashTemplateX").GetComponent<RectTransform>();
        dashTemplateY = graphContainer.Find("dashTemplateY").GetComponent<RectTransform>();
        
        xAxisText = graphContainer.Find("xAxisLabel").GetComponent<Text>();
        yAxisText = graphContainer.Find("yAxisLabel").GetComponent<Text>();
        titleText = graphContainer.Find("titleText").GetComponent<Text>();

        gameObjectList = new List<GameObject>();

        List<int> valueList = new List<int>() { 5, 98, 56, 45, 30, 22, 17, 15, 13, 17, 25, 37, 40, 36, 33, 50, 30, 60, 50, 40, 20, 5, 20, 10, 50, 30, 20, 11 };


        //coordinates1 = new List<List<float>>() {
        //    new List<float> { 0, 0 },
        //    new List<float> { 2, 2 },
        //    new List<float> { 4, 4 },
        //    new List<float> { 6, 6 },
        //    new List<float> { 8, 8 },
        //    new List<float> { 10, 10 },
        //    new List<float> { 12, 12 },
        //};


        ////Demand
        //coordinates2 = new List<List<float>>() { 
        //    new List<float> { 12, 0 }, 
        //    new List<float> { 10, 2 },
        //    new List<float> { 8, 4 },
        //    new List<float> { 6, 6 },
        //    new List<float> { 4, 8 },
        //    new List<float> { 2, 10 },
        //    new List<float> { 0, 12 },
        //};
        //ShowGDPGraph(valueList);
        ShowGDPGraph(valueList);
    }

    private void Start()
    {
        
    }



    private void DrawGraph(List<List<float>> coords, float xMaximum, float yMaximum, string colour = "")
    {
        float graphWidth = graphContainer.sizeDelta.x;
        float graphHeight = graphContainer.sizeDelta.y;

        GameObject lastPointGameObject = null;
        for (int i = 0; i < coords.Count; i++)
        {
            float xPosition = coords[i][0] / xMaximum * graphWidth;
            float yPosition = coords[i][1] / yMaximum * graphHeight;
            GameObject pointGameObject = CreatePoint(new Vector2(xPosition, yPosition));
            gameObjectList.Add(pointGameObject);
            if (lastPointGameObject != null)
            {
                GameObject pointConnectionGameObject = CreatePointConnections(lastPointGameObject.GetComponent<RectTransform>().anchoredPosition, pointGameObject.GetComponent<RectTransform>().anchoredPosition, colour);
                gameObjectList.Add(pointConnectionGameObject);
            }
            lastPointGameObject = pointGameObject;
        }
    }

    private void ClearList()
    {
        foreach (GameObject gameObject in gameObjectList)
        {
            Destroy(gameObject);
        }
        gameObjectList.Clear();
    }
    public void ShowDSGraph(Item item)
    {
        ShowDSGraph(item.supplyCurve, item.demandCurve, item);
    }
    public void ShowDSGraph(List<List<float>> supply, List<List<float>> demand, Item itemRef)
    {
        ClearList();

        float graphWidth = graphContainer.sizeDelta.x;
        float graphHeight = graphContainer.sizeDelta.y;

        float xMaximum = 0f;
        float yMaximum = 0f;

        //Set Text
        titleText.text = "Supply and Demand of " + itemRef.name + "s";
        xAxisText.text = "Quantity";
        yAxisText.text = "P\nr\ni\nc\ne\n($)";

        foreach(List<float> cords in supply)
        {
            if(cords[0] > xMaximum)
            {
                xMaximum = cords[0];
            }
            if(cords[1] > yMaximum)
            {
                yMaximum = cords[1];
            }
        }
        foreach (List<float> cords in demand)
        {
            if (cords[0] > xMaximum)
            {
                xMaximum = cords[0];
            }
            if (cords[1] > yMaximum)
            {
                yMaximum = cords[1];
            }
        }

        xMaximum = xMaximum * 1.1f;
        yMaximum = yMaximum * 1.1f;

        //Draw supply graph
        DrawGraph(supply, xMaximum, yMaximum, "red");

        //Draw Demand graph
        DrawGraph(demand, xMaximum, yMaximum, "blue");

        
        //Draw x and y axis dashes and labels
        int separatorCount = 10;
        for (int i = 0; i <= separatorCount; i++)
        {
            float normalizedValue = i * 1f / separatorCount;

            RectTransform labelX = Instantiate(labelTemplateX);
            labelX.SetParent(graphContainer);
            labelX.gameObject.SetActive(true);
            labelX.anchoredPosition = new Vector2(normalizedValue * graphWidth, -7f);
            labelX.GetComponent<Text>().text = Mathf.RoundToInt(xMaximum * normalizedValue).ToString();


            RectTransform dashX = Instantiate(dashTemplateX);
            dashX.SetParent(graphContainer);
            dashX.gameObject.SetActive(true);
            dashX.anchoredPosition = new Vector2(normalizedValue * graphWidth, -7f);
            dashX.localScale = new Vector3(1, 1, 1);

            RectTransform labelY = Instantiate(labelTemplateY);
            labelY.SetParent(graphContainer);
            labelY.gameObject.SetActive(true);
            labelY.anchoredPosition = new Vector2(-7f, normalizedValue * graphHeight);
            labelY.GetComponent<Text>().text = Mathf.RoundToInt(yMaximum * normalizedValue).ToString();

            RectTransform dashY = Instantiate(dashTemplateY);
            dashY.SetParent(graphContainer);
            dashY.gameObject.SetActive(true);
            dashY.anchoredPosition = new Vector2(-4f, normalizedValue * graphHeight);
            dashY.localScale = new Vector3(1, 1, 1);

            gameObjectList.Add(labelX.gameObject);
            gameObjectList.Add(dashX.gameObject);
            gameObjectList.Add(labelY.gameObject);
            gameObjectList.Add(dashY.gameObject);
        }
    }

    public void ShowGraph(List<List<float>> coordinates)
    {
        Debug.Log("Showing graph");

        float graphWidth = graphContainer.sizeDelta.x;
        float graphHeight = graphContainer.sizeDelta.y;

        float xMaximum = 0f;
        float yMaximum = 0f;

        GameObject lastPointGameObject = null;
        for (int i = 0; i < coordinates.Count; i++)
        {
            float xPosition = coordinates[i][0] / xMaximum * graphWidth;
            float yPosition = coordinates[i][1] / yMaximum * graphHeight;
            GameObject pointGameObject = CreatePoint(new Vector2(xPosition, yPosition));

            if (lastPointGameObject != null)
            {
                GameObject pointConnectionGameObject = CreatePointConnections(lastPointGameObject.GetComponent<RectTransform>().anchoredPosition, pointGameObject.GetComponent<RectTransform>().anchoredPosition);
                gameObjectList.Add(pointGameObject);
            }
            lastPointGameObject = pointGameObject;
        }

        int separatorCount = 10;
        for (int i = 0; i <= separatorCount; i++)
        {
            float normalizedValue = i * 1f / separatorCount;

            RectTransform labelX = Instantiate(labelTemplateX);
            labelX.SetParent(graphContainer);
            labelX.gameObject.SetActive(true);
            labelX.anchoredPosition = new Vector2(normalizedValue * graphWidth, -7f);
            labelX.GetComponent<Text>().text = Mathf.RoundToInt(xMaximum * normalizedValue).ToString();


            RectTransform dashX = Instantiate(dashTemplateX);
            dashX.SetParent(graphContainer);
            dashX.gameObject.SetActive(true);
            dashX.anchoredPosition = new Vector2(normalizedValue * graphWidth, -7f);

            RectTransform labelY = Instantiate(labelTemplateY);
            labelY.SetParent(graphContainer);
            labelY.gameObject.SetActive(true);
            labelY.anchoredPosition = new Vector2(-7f, normalizedValue * graphHeight);
            labelY.GetComponent<Text>().text = Mathf.RoundToInt(yMaximum * normalizedValue).ToString();
            gameObjectList.Add(labelY.gameObject);

            RectTransform dashY = Instantiate(dashTemplateY);
            dashY.SetParent(graphContainer);
            dashY.gameObject.SetActive(true);
            dashY.anchoredPosition = new Vector2(-4f, normalizedValue * graphHeight);
            gameObjectList.Add(dashY.gameObject);


        }
    }
    private void ShowGDPGraph(List<int> valueList, int maxVisibleValueAmount = -1, Func<int, string> getAxisLabelX = null, Func<float, string> getAxisLabelY = null)
    {
        if (getAxisLabelX == null)
        {
            getAxisLabelX = delegate (int _i) { return _i.ToString(); };
        }
        if (getAxisLabelY == null)
        {
            getAxisLabelY = delegate (float _f) { return Mathf.RoundToInt(_f).ToString(); };
        }

        if (maxVisibleValueAmount <= 0)
        {
            maxVisibleValueAmount = valueList.Count;
        }

        ClearList();

        float graphWidth = graphContainer.sizeDelta.x;
        float graphHeight = graphContainer.sizeDelta.y;

        float yMaximum = valueList[0];
        float yMinimum = valueList[0];

        //Set Text
        titleText.text = "GDP";
        xAxisText.text = "Time";
        yAxisText.text = "C\nA\nD\n($)";

        for (int i = Mathf.Max(valueList.Count - maxVisibleValueAmount, 0); i < valueList.Count; i++)
        {
            int value = valueList[i];
            if (value > yMaximum)
            {
                yMaximum = value;
            }
            if (value < yMinimum)
            {
                yMinimum = value;
            }
        }

        float yDifference = yMaximum - yMinimum;
        if (yDifference <= 0)
        {
            yDifference = 5f;
        }
        yMaximum = yMaximum + (yDifference * 0.2f);
        yMinimum = yMinimum - (yDifference * 0.2f);

        yMinimum = 0f; // Start the graph at zero

        float xSize = graphWidth / (maxVisibleValueAmount + 1);

        int xIndex = 0;

        GameObject lastCircleGameObject = null;
        for (int i = Mathf.Max(valueList.Count - maxVisibleValueAmount, 0); i < valueList.Count; i++)
        {
            float xPosition = xSize + xIndex * xSize;
            float yPosition = ((valueList[i] - yMinimum) / (yMaximum - yMinimum)) * graphHeight;
            GameObject circleGameObject = CreatePoint(new Vector2(xPosition, yPosition));
            gameObjectList.Add(circleGameObject);
            if (lastCircleGameObject != null)
            {
                GameObject dotConnectionGameObject = CreatePointConnections(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);
                gameObjectList.Add(dotConnectionGameObject);
            }
            lastCircleGameObject = circleGameObject;

            RectTransform labelX = Instantiate(labelTemplateX);
            labelX.SetParent(graphContainer, false);
            labelX.gameObject.SetActive(true);
            labelX.anchoredPosition = new Vector2(xPosition, -7f);
            labelX.GetComponent<Text>().text = getAxisLabelX(i);
            gameObjectList.Add(labelX.gameObject);

            RectTransform dashX = Instantiate(dashTemplateX);
            dashX.SetParent(graphContainer, false);
            dashX.gameObject.SetActive(true);
            dashX.anchoredPosition = new Vector2(xPosition, -3f);
            gameObjectList.Add(dashX.gameObject);

            xIndex++;
        }

        int separatorCount = 10;
        for (int i = 0; i <= separatorCount; i++)
        {
            RectTransform labelY = Instantiate(labelTemplateY);
            labelY.SetParent(graphContainer, false);
            labelY.gameObject.SetActive(true);
            float normalizedValue = i * 1f / separatorCount;
            labelY.anchoredPosition = new Vector2(-7f, normalizedValue * graphHeight);
            labelY.GetComponent<Text>().text = getAxisLabelY(yMinimum + (normalizedValue * (yMaximum - yMinimum)));
            gameObjectList.Add(labelY.gameObject);

            RectTransform dashY = Instantiate(dashTemplateY);
            dashY.SetParent(graphContainer, false);
            dashY.gameObject.SetActive(true);
            dashY.anchoredPosition = new Vector2(-4f, normalizedValue * graphHeight);
            gameObjectList.Add(dashY.gameObject);
        }
    }

    private GameObject CreatePointConnections(Vector2 pointA, Vector2 pointB, string colour)
    {
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);

        if(colour == "red")
        {
            gameObject.GetComponent<Image>().color = new Color(1, 0, 0, 0.5f);
        }
        else
        {
            //colour == "blue"
            gameObject.GetComponent<Image>().color = new Color(0, 0, 1, 0.5f);
        }
       
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();

        Vector2 dir = (pointB - pointA).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        float distance = Vector2.Distance(pointA, pointB);


        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, 3f);
        rectTransform.anchoredPosition = pointA + dir * distance * .5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, angle);

        return gameObject;
    }
    private GameObject CreatePointConnections(Vector2 pointA, Vector2 pointB)
    {
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();

        Vector2 dir = (pointB - pointA).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        float distance = Vector2.Distance(pointA, pointB);


        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, 3f);
        rectTransform.anchoredPosition = pointA + dir * distance * .5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, angle);

        return gameObject;
    }
    private GameObject CreatePoint(Vector2 anchoredPosition)
    {
        GameObject gameObject = new GameObject("point", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = pointSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(11, 11);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);

        return gameObject;
    }

}
