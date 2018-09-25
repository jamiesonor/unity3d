using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class BaseItem {
	
	private string itemName;
	private string itemDescription;
	private int itemID;
	private int vitality;
	private int strength;
	private int agility;
	private int intellect;
	private int wisdom;
	private int luck;

	public enum ItemTypes{
		WEAPON,
		ARMOR,
		POTION
	}

	private ItemTypes itemType;

	public BaseItem ()
	{

	}

	public BaseItem (Dictionary<string, string> itemsDictionary)
	{
		itemName = itemsDictionary["ItemName"];
		itemID = int.Parse(itemsDictionary["ItemID"]);
		itemType = (ItemTypes)System.Enum.Parse (typeof(BaseItem.ItemTypes), itemsDictionary ["ItemType"].ToString ());
	}

	public string ItemName
	{
		get{ return itemName;}
		set{ itemName = value;}
	}

	public string ItemDescription
	{
		get{ return itemDescription;}
		set{ itemDescription = value;}
	}

	public int ItemID
	{
		get{ return itemID;}
		set{ itemID = value;}
	}

	public ItemTypes ItemType
	{
		get{ return itemType;}
		set{ itemType = value;}
	}
	public int Vitality
	{
		get{ return vitality;}
		set{ vitality = value;}
	}
	public int Strength
	{
		get{ return strength;}
		set{ strength = value;}
	}
	public int Agility
	{
		get{ return agility;}
		set{ agility = value;}
	}
	public int Intellect
	{
		get{ return intellect;}
		set{ intellect = value;}
	}
	public int Wisdom
	{
		get{ return wisdom;}
		set{ wisdom = value;}
	}
	public int Luck{
		get{ return luck;}
		set{ luck = value;}
	}
}
