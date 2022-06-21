using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GovernmentInvestmentUI : MonoBehaviour
{
    [SerializeField] public Text nameText;
    [SerializeField] private Text amtText;
    [SerializeField] private Button investButton;
    private WorldManager wManager;
    private GovUI govUI;
    private Government gov;
    private Shop shopReceiver;

    private void Awake()
    {
        wManager = FindObjectOfType<WorldManager>().GetComponent<WorldManager>();
        govUI = FindObjectOfType<GovUI>().GetComponent<GovUI>();
        investButton.onClick.AddListener(Invest);
        gov = FindObjectOfType<Government>().GetComponent<Government>();
    }
    public void OpenUI()
    {
        transform.gameObject.SetActive(true);
    }

    private void Invest()
    {
        if(nameText.transform.parent.transform.Find("Placeholder").GetComponent<Text>().text == "Infrastructure")
        {
            float money = float.Parse(amtText.text);
            gov.SpendMoney(money);
            govUI.UpdateText();

            return;
        }

        float amtOfMOney = float.Parse(amtText.text);
        shopReceiver = wManager.GetShopByString(nameText.text);

        gov.SpendMoney(amtOfMOney);
        shopReceiver.AddMoney(amtOfMOney);

        govUI.UpdateText();
    }
}
