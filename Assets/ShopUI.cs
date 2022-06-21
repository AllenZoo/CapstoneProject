using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private Text titleText;
    [SerializeField] private Text ownerText;
    [SerializeField] private Text stuffBeingSoldText;
    [SerializeField] private Text amountOfMoneyText;
    [SerializeField] private Text revenuePerDayText;
    [SerializeField] private Text assetValueText;
    [SerializeField] private Button investmentButton;
    private BusinessInvestmentUI businessInvestmentUI;
    private Shop shopRef;

    private void Awake()
    {
        investmentButton = transform.Find("investInOtherShopButton").GetComponent<Button>();
        businessInvestmentUI = FindObjectOfType<BusinessInvestmentUI>().GetComponent<BusinessInvestmentUI>();
    }

    private void Start()
    {
        investmentButton.onClick.AddListener(InvestButtonClicked);
    }

    public void SetText(Shop shop)
    {
        shopRef = shop;
        titleText.text = shop.name;
        ownerText.text = "Owner: " + shop.owner.citizenName;
        stuffBeingSoldText.text = "Items being sold: " + "";

        foreach (Item item in shop.itemsBeingSold)
        {
            stuffBeingSoldText.text += item.itemType.ToString() + ", ";
        }

        amountOfMoneyText.text = "Amount of money: $" + shop.amtOfMoney.ToString();
        revenuePerDayText.text = "Revenue per Day: $" + shop.revenuePerDay.ToString();
    }

    public void UpdateText()
    {
        SetText(shopRef);
    }

    private void InvestButtonClicked()
    {
        businessInvestmentUI.OpenUI(shopRef);
    }
}
