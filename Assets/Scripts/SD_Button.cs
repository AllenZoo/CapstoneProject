using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SD_Button : MonoBehaviour
{
    public SD_Options sdOptions;
    private Button button;
    private Text text;
    private Item.ItemType itemType;

    private void Awake()
    {
        sdOptions = FindObjectOfType<SD_Options>().GetComponent<SD_Options>();
        text = transform.Find("Text").GetComponent<Text>();
        button = transform.GetComponent<Button>();
    }

    private void Start()
    {
        GetItemTypeByText(text);
        button.onClick.AddListener(OnButtonClick);
    }

    private void GetItemTypeByText(Text text)
    {
        string _text = text.text;

        switch (_text) {
            case "Apple": itemType = Item.ItemType.Apple;
                break;
            case "Cake": itemType = Item.ItemType.Cake;
                break;
            case "Clothes": itemType = Item.ItemType.Clothes;
                break;
            default: 
                break;

        }
    }

    private void OnButtonClick()
    {
        sdOptions.ButtonClicked(itemType);
        sdOptions.gameObject.SetActive(false);
    }

}
