using UnityEngine;
using System.Collections;

[System.Serializable]
public class BaseEndurance : BaseStat {

	public BaseEndurance ()
    {
        StatName = "Endurance";
        StatDescription = "Directly modifies player's energy.";
        StatType = StatTypes.ENDURANCE;
        StatBaseValue = 0;
        StatModifiedValue = 0;
    }
}
