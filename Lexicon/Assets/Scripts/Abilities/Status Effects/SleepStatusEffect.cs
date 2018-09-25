[System.Serializable]

public class SleepStatusEffect : BaseStatusEffect {

	public SleepStatusEffect ()
	{
		StatusEffectName = "Sleep";
		StatusEffectDescription = "Puts enemy to sleep for a number of turns";
		StatusEffectID = 2;
		StatusEffectPower = 0;
		StatusEffectApplyPercentage = 100; //75% chance to be applied
		StatusEffectStayAppliedPercentage = 25;
		StatusEffectMinTurnApplied = 2;
		StatusEffectMaxTurnApplied = 3;
	}
}
