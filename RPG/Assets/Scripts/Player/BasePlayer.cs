using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasePlayer : MonoBehaviour {

    private List<BaseStat> _playerStats = new List<BaseStat>();

    private List<BaseItem> _inventory = new List<BaseItem>();

	// Use this for initialization
	void Awake () {
	    for(int i = 0; i < 10; i++)
        {
            BaseItem _item = new BaseItem();
            _item.ItemType = BaseItem.GetRandomEnum<BaseItem.ItemTypes>();
            _inventory.Add(_item);
            /*Debug.Log(_inventory[i].ItemName);
            Debug.Log(_inventory[i].ItemDescription);
            Debug.Log(_inventory[i].ItemValue);
            Debug.Log(_inventory[i].ItemType);
            Debug.Log(_inventory[i].ItemStats[0].StatName);
            Debug.Log(_inventory[i].ItemStats[0].StatDescription);
            Debug.Log(_inventory[i].ItemStats[0].StatType);*/
        }

        /*BaseItem _item = new BaseItem();
        _inventory.Add(_item);
        BaseItem _itemTwo = new BaseItem();
        _itemTwo.ItemType = BaseItem.ItemTypes.WEAPON;
        _inventory.Add(_itemTwo);*/

        Debug.Log(_inventory.Count);    //we have 10 items (or i items) in the inventory
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public List<BaseItem> ReturnPlayerInventory()
    {
        return _inventory;
    }
}
