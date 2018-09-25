using UnityEngine;
using System.Collections;

public class BaseStat {

    private string _name;
    private string _description;
    private int _baseValue;
    private int _modifiedValue;
    private StatTypes _type;

    public enum StatTypes
    {
        STAMINA,
        ENDURANCE,
        INTELLECT,
        MASTERY,
        STRENGTH
    }

    public string StatName
    {
        get { return _name; }
        set { _name = value; }
    }
    public string StatDescription
    {
        get { return _description; }
        set { _description = value; }
    }
    public int StatBaseValue
    {
        get { return _baseValue; }
        set { _baseValue = value; }
    }
    public int StatModifiedValue
    {
        get { return _modifiedValue; }
        set { _modifiedValue = value; }
    }
    public StatTypes StatType
    {
        get { return _type; }
        set { _type = value; }
    }
}
