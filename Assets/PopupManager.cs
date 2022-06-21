using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    [SerializeField] private GovUI govUI;
    [SerializeField] private ShopUI shopUI;

    private void Awake()
    {
        govUI = FindObjectOfType<GovUI>().GetComponent<GovUI>();
        shopUI = FindObjectOfType<ShopUI>().GetComponent<ShopUI>();
    }

    public void CloseUI()
    {
        govUI.gameObject.SetActive(false);
        shopUI.gameObject.SetActive(false);
    }

    public void OpenShopOutline(Shop shop)
    {
        shopUI.gameObject.SetActive(true);
        shopUI.SetText(shop);
    }

    public void OpenGovOutline()
    {
        govUI.gameObject.SetActive(true);

    }
}
