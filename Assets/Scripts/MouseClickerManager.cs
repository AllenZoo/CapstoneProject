using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickerManager : MonoBehaviour
{
    private PopupManager popUpManager;

    private void Start()
    {
        popUpManager = FindObjectOfType<PopupManager>().GetComponent<PopupManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Check for mouse click 
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                ProcessClickedGameObject(hit.collider.gameObject);
            }
            else
            {
                ProcessClickedGameObject(null);
            }
        }
    }

    private void ProcessClickedGameObject(GameObject gameObject)
    {
        if(gameObject == null)
        {
            //popUpManager.CloseUI();
            return;
        }
        
        if(gameObject.tag == "Shop")
        {
            popUpManager.CloseUI();
            popUpManager.OpenShopOutline(gameObject.GetComponent<Shop>());
        }
        else if(gameObject.tag == "Government Building")
        {
            popUpManager.CloseUI();
            popUpManager.OpenGovOutline();
        }
    }

}
