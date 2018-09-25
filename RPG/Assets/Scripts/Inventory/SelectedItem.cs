using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System;

public class SelectedItem : MonoBehaviour, IDragHandler, IPointerDownHandler {

    private Text selectedItemText;
    private List<BaseItem> playerInventory;

	// Use this for initialization
	void Start () {
        selectedItemText = GameObject.Find("SelectedItemText").GetComponent<Text>();
        BasePlayer basePlayerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<BasePlayer>();
        playerInventory = basePlayerScript.ReturnPlayerInventory();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowSelectedItemText()
    {
        if(this.gameObject.GetComponent<Toggle>().isOn)
        {
            if(this.gameObject.name == "Empty")
            {
                selectedItemText.text = "This slot is empty.";
            }
            else
            {
                selectedItemText.text = playerInventory[System.Int32.Parse(this.gameObject.name)].ItemName + " " + playerInventory[System.Int32.Parse(this.gameObject.name)].ItemDescription;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!GameObject.Find("InventoryWindow").GetComponent<InventoryWindow>().isBeingDragged && this.name != "Empty")
        {
            GameObject.Find("InventoryWindow").GetComponent<InventoryWindow>().ShowDraggedItem(this.transform.name);
            this.transform.GetChild(0).gameObject.SetActive(false);
            this.transform.name = "Empty";
        }
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("I clicked Down");'
        InventoryWindow inventoryWindow = GameObject.Find("InventoryWindow").GetComponent<InventoryWindow>();
        if (inventoryWindow.isBeingDragged)
        {
            if(this.name != "Empty")
            {
                inventoryWindow.SwapItem(this.gameObject);
            }
            else
            {
                this.transform.name = inventoryWindow.AddItemToSlot(this.gameObject);
                this.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
}
