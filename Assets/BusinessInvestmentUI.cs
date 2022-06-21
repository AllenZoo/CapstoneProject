using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BusinessInvestmentUI : MonoBehaviour
{
    [SerializeField] private Text nameText;
    [SerializeField] private Text amtText;
    [SerializeField] private Button investButton;
    private WorldManager wManager;
    private ShopUI shopUI;
    private Shop shopInvestor;
    private Shop shopReceiver;

    private void Awake()
    {
        wManager = FindObjectOfType<WorldManager>().GetComponent<WorldManager>();
        shopUI = FindObjectOfType<ShopUI>().GetComponent<ShopUI>();
        investButton.onClick.AddListener(Invest);        
    }


    public void OpenUI(Shop shop)
    {
        shopInvestor = shop;
        transform.gameObject.SetActive(true);
    }

    public void Invest()
    {
        float amtOfMOney = float.Parse(amtText.text);
        shopReceiver = wManager.GetShopByString(nameText.text);

        shopInvestor.SpendMoney(amtOfMOney);
        shopReceiver.AddMoney(amtOfMOney);

        shopUI.UpdateText();

        //Debug.Log("Name: " + nameText.text + "AmtText: " + amtText.text);
        //shopInvestor.amtOfMoney -= amtText.Stringto
    }

}
