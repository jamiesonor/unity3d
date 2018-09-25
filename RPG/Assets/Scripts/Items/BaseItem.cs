using UnityEngine;
using System.Collections.Generic;

public class BaseItem {

    private string _name;
    private string _description;
    private int _value;
    private List<BaseStat> _stats;
    private ItemTypes _type;

    //public Sprite icon;

    public BaseItem()
    {
        ItemName = "Item" + Random.Range(0, 101);
        ItemDescription = ItemName + " is an awesome item!";
        ItemValue = Random.Range(10, 500);
        ItemType = ItemTypes.EQUIPMENT;
        ItemStats = new List<BaseStat>();
        ItemStats.Add(new BaseStamina());
        ItemStats.Add(new BaseEndurance());
        //icon = Resources.Load<Sprite>("");
    }

    public enum ItemTypes
    {
        EQUIPMENT,
        WEAPON
    }

    public string ItemName
    {
        get { return _name; }
        set { _name = value; }
    }
    public string ItemDescription
    {
        get { return _description; }
        set { _description = value; }
    }
    public int ItemValue
    {
        get { return _value; }
        set { _value = value; }
    }
    public List<BaseStat> ItemStats
    {
        get { return _stats; }
        set { _stats = value; }
    }
    public ItemTypes ItemType
    {
        get { return _type; }
        set { _type = value; }
    }

    public static ItemTypes GetRandomEnum<ItemTypes>()
    {
        System.Array enumTypes = System.Enum.GetValues(typeof(ItemTypes));
        ItemTypes randomItemType = (ItemTypes)enumTypes.GetValue(UnityEngine.Random.Range(0, enumTypes.Length));
        return randomItemType;
    }
}
