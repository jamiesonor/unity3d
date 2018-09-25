using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InventoryWindow : MonoBehaviour {

    public int startingPosX;
    public int startingPosY;
    public int slotCntPerPage;
    public int slotCntLength;
    public GameObject itemSlotPrefab;
    public ToggleGroup itemSlotToggleGroup;

    public GameObject draggedIcon;
    public BaseItem itemBeingDragged;
    public bool isBeingDragged = false;
    private const int mousePositionOffset = 30;
    private string slotName;


    private int xPos;
    private int yPos;
    private GameObject itemSlot;
    private int itemSlotCnt;
    private List<GameObject> inventorySlots;

    private List<BaseItem> playerInventory;

	// Use this for initialization
	void Start () {
        CreateInventorySlotsInWindow();
        AddItemsFromInventory();
    }
	
	// Update is called once per frame
	void Update () {
        if(isBeingDragged)
        {
            Vector3 mousePosition = (Input.mousePosition - GameObject.FindGameObjectWithTag("Canvas").GetComponent<RectTransform>().localPosition);
            draggedIcon.GetComponent<RectTransform>().localPosition = new Vector3(mousePosition.x + mousePositionOffset, mousePosition.y - mousePositionOffset, mousePosition.z);
        }
	}

    //we need to store the item in another location, we can remove the item from our inventory
    //code some way to move the icon
    //we need to find the proper icon for the dragging image
    //we need to disable item icon on the selected item prefab
    public void ShowDraggedItem(string name)
    {
        Debug.Log("I am dragging!");
        slotName = name;
        isBeingDragged = true;
        draggedIcon.SetActive(true);    //this is the item we are dragging, we need to capture the item from the player inventory and then set the item image
        itemBeingDragged = playerInventory[int.Parse(name)];
        //Debug.Log(itemBeingDragged.ItemName);
        //Debug.Log(itemBeingDragged.ItemType);
        draggedIcon.GetComponent<Image>().sprite = ReturnItemIcon(itemBeingDragged);
    }


    public string AddItemToSlot (GameObject slot)
    {
        slot.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = ReturnItemIcon(playerInventory[int.Parse(slotName)]);
        draggedIcon.SetActive(false);
        itemBeingDragged = null;
        isBeingDragged = false;
        return slotName;
    }

    private void CreateInventorySlotsInWindow()
    {
        inventorySlots = new List<GameObject>();
        xPos = startingPosX;
        yPos = startingPosY;
        for (int i = 0; i < slotCntPerPage; i++)
        {
            itemSlot = (GameObject)Instantiate(itemSlotPrefab);
            itemSlot.name = "Empty";
            itemSlot.GetComponent<Toggle>().group = itemSlotToggleGroup;
            inventorySlots.Add(itemSlot);
            itemSlot.transform.SetParent(this.gameObject.transform);
            itemSlot.GetComponent<RectTransform>().localPosition = new Vector3(xPos, yPos, 0);
            xPos += (int)itemSlot.GetComponent<RectTransform>().rect.width;
            itemSlotCnt++;
            if(itemSlotCnt % slotCntLength == 0)
            {
                itemSlotCnt = 0;
                yPos -= (int)itemSlot.GetComponent<RectTransform>().rect.width;
                xPos = startingPosX;
            }
        }
    }

    private void AddItemsFromInventory()
    {
        BasePlayer basePlayerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<BasePlayer>();
        playerInventory = basePlayerScript.ReturnPlayerInventory();
        for (int i = 0; i < playerInventory.Count; i++)
        {
            if (inventorySlots[i].name == "Empty")
            {
                inventorySlots[i].name = i.ToString();
                //look at the item and add the proper icon to display
                inventorySlots[i].transform.GetChild(0).gameObject.SetActive(true);
                inventorySlots[i].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = ReturnItemIcon(playerInventory[i]);
            }
        }
    }

    private Sprite ReturnItemIcon(BaseItem item)
    {
        Sprite icon = new Sprite();
        if(item.ItemType == BaseItem.ItemTypes.EQUIPMENT)
        {
            icon = Resources.Load<Sprite>("ItemIcons/armor");
        }
        else
        {
            icon = Resources.Load<Sprite>("ItemIcons/sword");
        }
        return icon;
    }

    public void SwapItem(GameObject slot)
    {
        BaseItem swapItem = playerInventory[int.Parse(slot.name)];
        slot.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = ReturnItemIcon(itemBeingDragged);
        slot.name = slotName;
        itemBeingDragged = swapItem;
        draggedIcon.GetComponent<Image>().sprite = ReturnItemIcon(itemBeingDragged);
        slotName = playerInventory.FindIndex(x => x == itemBeingDragged).ToString();
    }
}
