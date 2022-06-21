using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GovUI : MonoBehaviour
{
    [SerializeField] private Text amountOfMoneyText;
    [SerializeField] private Text taxRateText;
    [SerializeField] private Text revenuePerDayText;
    [SerializeField] private Button investmentButton;
    [SerializeField] private Button infrastructureInvestmentButton;
    private GovernmentInvestmentUI govUIInvestment;
    private Government govRef;

    private void Awake()
    {
        govRef = FindObjectOfType<Government>().GetComponent<Government>();
        investmentButton = transform.Find("investInShopButton").GetComponent<Button>();
        govUIInvestment = FindObjectOfType<GovernmentInvestmentUI>().GetComponent<GovernmentInvestmentUI>();

        investmentButton.onClick.AddListener(InvestButtonClicked);
        infrastructureInvestmentButton.onClick.AddListener(InfraInvButtonClicked);
    }

    private void Start()
    {
        UpdateText();
    }
    public void UpdateText()
    {
        Debug.Log(govRef.revenuePerDay);
        amountOfMoneyText.text = "Amount of money: " + govRef.amtOfMoney.ToString();
        taxRateText.text = "Tax Rate: " + govRef.taxRate * 100 + "%";
        revenuePerDayText.text = "Revenue per day: $" + govRef.revenuePerDay.ToString();
    }

    private void InvestButtonClicked()
    {
        govUIInvestment.OpenUI();
    }

    private void InfraInvButtonClicked()
    {
        govUIInvestment.OpenUI();
        govUIInvestment.nameText.transform.parent.transform.Find("Placeholder").GetComponent<Text>().text = "Infrastructure";
    }
}
