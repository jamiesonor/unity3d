using UnityEngine;
using System.Collections;

[System.Serializable]
public class BaseMastery : BaseStat {

	public BaseMastery()
    {
        StatName = "Mastery";
        StatDescription = "Directly modifies player's mastery.";
        StatType = StatTypes.MASTERY;
        StatBaseValue = 0;
        StatModifiedValue = 0;
    }
}
