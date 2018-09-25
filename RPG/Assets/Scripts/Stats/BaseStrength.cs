using UnityEngine;
using System.Collections;

[System.Serializable]
public class BaseStrength : BaseStat {

    public BaseStrength()
    {
        StatName = "Strength";
        StatDescription = "Directly modifies player's strength.";
        StatType = StatTypes.STRENGTH;
        StatBaseValue = 0;
        StatModifiedValue = 0;
    }
}
