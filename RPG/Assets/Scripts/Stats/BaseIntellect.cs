using UnityEngine;
using System.Collections;

[System.Serializable]
public class BaseIntellect : BaseStat {

	public BaseIntellect ()
    {
        StatName = "Intellect";
        StatDescription = "Directly modifies player's intelligence.";
        StatType = StatTypes.INTELLECT;
        StatBaseValue = 0;
        StatModifiedValue = 0;
    }
}
